using System.Collections.Concurrent;
using System.Text.Json;
using FC4.HotelReservation.Shared.Domain;

namespace FC4.HotelReservation.Shared.Infrastructure.Models;

public class EventEntry
{
    private static readonly ConcurrentDictionary<string, Type> TypeCache = new();
    private EventEntry() { } // For EF Core
    public EventEntry(Guid eventId, Guid aggregateId, int aggregateVersion, string eventType, string eventData,
        DateTime occurredOn)
    {
        EventId = eventId;
        AggregateId = aggregateId;
        EventType = eventType;
        EventData = eventData;
        OccurredOn = occurredOn;
        AggregateVersion = aggregateVersion;
    }
    public Guid EventId { get; private set; }
    public Guid AggregateId { get; private set; }
    public int AggregateVersion { get; private set; }
    public string EventType { get; private set; } = null!;
    public string EventData { get; private set; } = null!;
    public DateTime OccurredOn { get; private set; }

    public static EventEntry FromDomainEvent(DomainEvent domainEvent)
        => new(domainEvent.EventId,
            domainEvent.AggregateId,
            domainEvent.AggregateVersion,
            domainEvent.GetType().Name,
            JsonSerializer.Serialize(domainEvent, domainEvent.GetType()),
            domainEvent.OccuredOn);

    public DomainEvent ToDomainEvent()
    {
        var type = TypeCache.GetOrAdd(EventType, name =>
            AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .FirstOrDefault(t => t.Name == name && t.IsSubclassOf(typeof(DomainEvent)))
            ?? throw new InvalidOperationException(
                $"Unknown event type: '{name}'. No DomainEvent subclass with this name was found in loaded assemblies."));
        return (DomainEvent)JsonSerializer.Deserialize(EventData, type)!;
    }
}