using System.Text.Json;
using FC4.HotelReservation.Shared.Domain;

namespace FC4.HotelReservation.Shared.Infrastructure.Models;

public class EventEntry
{
    private EventEntry() { } // For EF Core
    private EventEntry(Guid eventId, Guid aggregateId, int aggregateVersion, string eventType, string eventData,
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
}