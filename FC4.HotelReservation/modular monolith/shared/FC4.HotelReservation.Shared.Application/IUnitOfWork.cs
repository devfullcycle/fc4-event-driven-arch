using FC4.HotelReservation.Shared.Domain;

namespace FC4.HotelReservation.Shared.Application;

public interface IUnitOfWork
{
    Task CommitAsync(CancellationToken cancellationToken);
    void Register(AggregateRoot aggregateRoot);
}