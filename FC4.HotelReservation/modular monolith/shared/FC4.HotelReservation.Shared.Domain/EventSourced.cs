namespace FC4.HotelReservation.Shared.Domain;

public abstract class EventSourced : AggregateRoot
{
    private readonly Dictionary<Type, Action<DomainEvent>> _handlers = new();

    protected EventSourced() { }
    protected EventSourced(Guid id) : base(id) { }
    public int Version { get; protected set; } = -1;

    protected void Register<T>(Action<T> handler) where T : DomainEvent
    {
        _handlers[typeof(T)] = e => handler((T)e);
    }

    private void Apply(DomainEvent domainEvent)
    {
        var eventType = domainEvent.GetType();

        if (!_handlers.TryGetValue(eventType, out var handler))
            throw new InvalidOperationException(
                $"No handler registered for {eventType.Name} on {GetType().Name}");

        handler(domainEvent);
    }

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