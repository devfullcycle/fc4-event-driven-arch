using FC4.HotelReservation.Shared.Application;
using FC4.HotelReservation.Shared.Application.Exceptions;
using FC4.HotelReservation.Shared.Domain;
using FC4.HotelReservation.Shared.Infrastructure.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Npgsql;

namespace FC4.HotelReservation.Shared.Infrastructure;

public class UnitOfWork(
    HotelDbContext dbContext,
    IPublisher publisher) : IUnitOfWork
{
    private const int SnapshotInterval = 5;
    private readonly IDbContextTransaction _transaction = dbContext.Database.BeginTransaction();
    private readonly List<AggregateRoot> _registeredAggregates = [];

    public void Register(AggregateRoot aggregateRoot)
    {
        if (!_registeredAggregates.Contains(aggregateRoot))
            _registeredAggregates.Add(aggregateRoot);
    }

    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        List<AggregateRoot> aggregateRoots;
        do
        {
            aggregateRoots = dbContext
                .ChangeTracker
                .Entries<AggregateRoot>()
                .Select(entry => entry.Entity)
                .Union(_registeredAggregates)
                .Where(entity => entity.Events.Count > 0)
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
        } while (aggregateRoots.Any());
        
        SaveSnapshots();

        try
        {
            await dbContext.SaveChangesAsync(cancellationToken);
            await _transaction.CommitAsync(cancellationToken);
        }
        catch (Exception ex)
            when (ex.InnerException is PostgresException
                  {
                      MessageText:
                      "duplicate key value violates unique constraint \"uix_event_store_aggregate_id_version\""
                  })
        {
            throw new ConflictException("Concurrency conflict occurred during save operation", ex);
        }
        finally
        {
            await _transaction.DisposeAsync();
        }
    }

    private void SaveSnapshots()
    {
        var eventSourcedAggregates = _registeredAggregates.OfType<EventSourced>()
            .Distinct()
            .Where(a => a.Version > 0 && a.Version % SnapshotInterval == 0);
        
        foreach (var aggregate in eventSourcedAggregates)
        {

            dbContext.Snapshots.Add(new SnapshotEntry(
                aggregate.Id,
                aggregate.GetType().Name,
                aggregate.Version,
                SnapshotJsonOptions.Serialize(aggregate),
                DateTime.UtcNow));
        }
    }
}