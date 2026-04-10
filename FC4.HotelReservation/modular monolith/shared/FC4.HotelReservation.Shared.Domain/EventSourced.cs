namespace FC4.HotelReservation.Shared.Domain;

public abstract class EventSourced : AggregateRoot
{
    protected EventSourced() { }
    protected EventSourced(Guid id) : base(id) { }
    public int Version { get; protected set; } = -1;

    protected abstract void Apply(DomainEvent domainEvent);
    
    public void Load(IEnumerable<DomainEvent> history)
    {
        foreach (var domainEvent in history)
        {
            Apply(domainEvent);
            Version = domainEvent.AggregateVersion;
        }
    }

    protected override void RaiseEvent(DomainEvent @event)
    {
        Apply(@event);
        Version++;
        @event.AggregateVersion = Version;
        @event.AggregateId = Id;
        base.RaiseEvent(@event);
    }
}