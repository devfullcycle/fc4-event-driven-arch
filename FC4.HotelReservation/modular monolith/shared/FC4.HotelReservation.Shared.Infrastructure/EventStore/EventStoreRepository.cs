using FC4.HotelReservation.Shared.Application;
using FC4.HotelReservation.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace FC4.HotelReservation.Shared.Infrastructure.EventStore;

public class EventStoreRepository<T>(HotelDbContext dbContext,
    IUnitOfWork unitOfWork) where T : EventSourced
{
    public async Task<T?> LoadFromEventsAsync(Guid aggregateId, CancellationToken cancellationToken)
    {
        var (aggregate, snapshotVersion) = await LoadSnapshotAsync(aggregateId, cancellationToken);
        
        var entries = await dbContext.EventStore
            .Where(e => e.AggregateId == aggregateId && e.AggregateVersion > snapshotVersion)
            .OrderBy(e => e.AggregateVersion)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
        
        if (aggregate is null && entries.Count == 0)
            return null;
        
        aggregate ??= (T)Activator.CreateInstance(typeof(T), nonPublic: true)!;
        aggregate.Load(entries.Select(e => e.ToDomainEvent()));
        unitOfWork.Register(aggregate);
        return aggregate;
    }
    
    private async Task<(T? Aggregate, int Version)> LoadSnapshotAsync(
        Guid aggregateId, CancellationToken cancellationToken)
    {
        var snapshot = await dbContext.Snapshots
            .Where(s => s.AggregateId == aggregateId)
            .OrderByDescending(s => s.AggregateVersion)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);

        if (snapshot is null)
            return (null, -1);

        var aggregate = SnapshotJsonOptions.Deserialize<T>(snapshot.SnapshotData);
        return (aggregate, snapshot.AggregateVersion);
    }
}