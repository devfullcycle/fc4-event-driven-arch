using FC4.HotelReservation.Shared.Application;
using FC4.HotelReservation.Shared.Application.Exceptions;
using FC4.HotelReservation.Shared.Domain;
using FC4.HotelReservation.Shared.Infrastructure.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace FC4.HotelReservation.Shared.Infrastructure;

public class UnitOfWork(
    HotelDbContext dbContext,
    IPublisher publisher) : IUnitOfWork
{
    private readonly IDbContextTransaction _transaction = dbContext.Database.BeginTransaction();
    private readonly List<AggregateRoot> _registeredAggregates = [];
    
    public void Register(AggregateRoot aggregateRoot)
    {
        if (!_registeredAggregates.Contains(aggregateRoot))
            _registeredAggregates.Add(aggregateRoot);
    }

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
                if (aggregateRoot is EventSourced)
                {
                    dbContext.EventStore.Add(EventEntry.FromDomainEvent(@event));
                }
                await publisher.Publish((dynamic)@event, cancellationToken);
                aggregateRoot.RemoveEvent(@event);
            }
        }

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