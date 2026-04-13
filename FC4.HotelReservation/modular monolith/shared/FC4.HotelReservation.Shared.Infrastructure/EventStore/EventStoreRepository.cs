using FC4.HotelReservation.Shared.Application;
using FC4.HotelReservation.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace FC4.HotelReservation.Shared.Infrastructure.EventStore;

public class EventStoreRepository<T>(HotelDbContext dbContext,
    IUnitOfWork unitOfWork) where T : EventSourced
{
    public async Task<T?> LoadFromEventsAsync(Guid aggregateId, CancellationToken cancellationToken)
    {
        var entries = await dbContext.EventStore
            .Where(e => e.AggregateId == aggregateId)
            .OrderBy(e => e.AggregateVersion)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
        
        if (entries.Count == 0)
            return null;
        
        var aggregate = (T)Activator.CreateInstance(typeof(T), nonPublic: true)!;
        aggregate.Load(entries.Select(e => e.ToDomainEvent()));
        unitOfWork.Register(aggregate);
        return aggregate;
    }
}