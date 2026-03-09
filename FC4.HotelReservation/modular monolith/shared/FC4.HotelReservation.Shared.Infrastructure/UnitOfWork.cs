using FC4.HotelReservation.Shared.Application;
using FC4.HotelReservation.Shared.Application.Exceptions;
using FC4.HotelReservation.Shared.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace FC4.HotelReservation.Shared.Infrastructure;

public class UnitOfWork(
    HotelDbContext dbContext,
    IPublisher publisher) : IUnitOfWork
{
    private readonly IDbContextTransaction _transaction = dbContext.Database.BeginTransaction();

    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        var aggregateRoots = dbContext
            .ChangeTracker
            .Entries<AggregateRoot>()
            .Where(entry => entry.Entity.Events.Count > 0)
            .Select(entry => entry.Entity)
            .ToList();

        foreach (var aggregateRoot in aggregateRoots)
        {
            foreach (var @event in aggregateRoot.Events.ToList())
            {
                await publisher.Publish((dynamic)@event, cancellationToken);
                aggregateRoot.RemoveEvent(@event);
            }
        }

        var versionedEntries = dbContext
            .ChangeTracker
            .Entries<IVersioned>()
            .Where(entry => entry.State == EntityState.Modified)
            .ToList();

        foreach (var entry in versionedEntries)
            entry.Property(nameof(IVersioned.Version)).CurrentValue = entry.Entity.Version + 1;

        try
        {
            await dbContext.SaveChangesAsync(cancellationToken);
            await _transaction.CommitAsync(cancellationToken);
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new ConflictException("Concurrency conflict occurred during save operation", ex);
        }
        finally
        {
            await _transaction.DisposeAsync();
        }
    }
}