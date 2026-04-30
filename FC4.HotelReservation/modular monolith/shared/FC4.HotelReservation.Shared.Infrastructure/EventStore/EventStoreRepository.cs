using FC4.HotelReservation.Shared.Application;
using FC4.HotelReservation.Shared.Domain;
using FC4.HotelReservation.Shared.Infrastructure.Models;
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

    public async Task<List<T>> LoadManyFromEventsAsync(IReadOnlyList<Guid> aggregateIds, CancellationToken cancellationToken)
    {
        if (aggregateIds.Count == 0)
            return [];

        var distinctIds = aggregateIds.Distinct().ToList();

        var snapshots = await LoadSnapshotsAsync(distinctIds, cancellationToken);

        var entriesByAggregate = await LoadEventsAfterSnapshotsAsync(distinctIds, snapshots, cancellationToken);

        var result = new List<T>();
        foreach (var id in distinctIds)
        {
            var hasSnapshot = snapshots.TryGetValue(id, out var snapshot);
            var aggregate = hasSnapshot ? snapshot.Aggregate : default;

            entriesByAggregate.TryGetValue(id, out var entries);

            if (aggregate is null && (entries is null || entries.Count == 0))
                continue;

            aggregate ??= (T)Activator.CreateInstance(typeof(T), nonPublic: true)!;
            if (entries is { Count: > 0 })
                aggregate.Load(entries.Select(e => e.ToDomainEvent()));

            unitOfWork.Register(aggregate);
            result.Add(aggregate);
        }

        return result;
    }

    private async Task<Dictionary<Guid, List<EventEntry>>> LoadEventsAfterSnapshotsAsync(
        List<Guid> aggregateIds,
        Dictionary<Guid, (T? Aggregate, int Version)> snapshots,
        CancellationToken cancellationToken)
    {
        var valuesClauses = new List<string>();
        var parameters = new List<object>();
        var paramIndex = 0;

        foreach (var id in aggregateIds)
        {
            var hasSnapshot = snapshots.TryGetValue(id, out var snapshot);
            var snapshotVersion = hasSnapshot ? snapshot.Version : -1;

            valuesClauses.Add($"({{{paramIndex}}}, {{{paramIndex + 1}}})");
            parameters.Add(id);
            parameters.Add(snapshotVersion);
            paramIndex += 2;
        }

        var sql = $"""
            SELECT e.event_id, e.aggregate_id, e.aggregate_version, e.event_type, e.event_data, e.occurred_on
            FROM event_store e
            INNER JOIN (VALUES {string.Join(", ", valuesClauses)}) AS s(agg_id, snap_ver)
              ON e.aggregate_id = s.agg_id AND e.aggregate_version > s.snap_ver
            ORDER BY e.aggregate_id, e.aggregate_version
            """;

        var entries = await dbContext.EventStore
            .FromSqlRaw(sql, parameters.ToArray())
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return entries
            .GroupBy(e => e.AggregateId)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    private async Task<Dictionary<Guid, (T? Aggregate, int Version)>> LoadSnapshotsAsync(
        List<Guid> aggregateIds, CancellationToken cancellationToken)
    {
        var ids = aggregateIds.ToArray();
        var latestSnapshots = await dbContext.Snapshots
            .FromSqlRaw("""
                SELECT DISTINCT ON (aggregate_id)
                       aggregate_id, aggregate_type, aggregate_version, snapshot_data, created_on
                FROM snapshots
                WHERE aggregate_id = ANY({0})
                ORDER BY aggregate_id, aggregate_version DESC
                """, ids)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return latestSnapshots.ToDictionary(
            s => s.AggregateId,
            s => (SnapshotJsonOptions.Deserialize<T>(s.SnapshotData), s.AggregateVersion));
    }
}