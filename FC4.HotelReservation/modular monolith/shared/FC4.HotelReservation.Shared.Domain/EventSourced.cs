namespace FC4.HotelReservation.Shared.Domain;

public abstract class EventSourced : AggregateRoot
{
    protected EventSourced() { }
    protected EventSourced(Guid id) : base(id) { }
    public int Version { get; protected set; } = -1;

    protected override void RaiseEvent(DomainEvent @event)
    {
        Version++;
        @event.AggregateVersion = Version;
        @event.AggregateId = Id;
        base.RaiseEvent(@event);
    }
}