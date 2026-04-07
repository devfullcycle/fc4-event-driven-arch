using MediatR;

namespace FC4.HotelReservation.Shared.Domain;

public abstract class DomainEvent : INotification
{
    public Guid EventId { get; private set; } = Guid.NewGuid();
    public Guid AggregateId { get; set; }
    public int AggregateVersion { get; set; }
    public DateTime OccuredOn { get; private set; } = DateTime.UtcNow;
}