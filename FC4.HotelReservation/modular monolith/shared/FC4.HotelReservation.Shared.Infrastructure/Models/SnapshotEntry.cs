namespace FC4.HotelReservation.Shared.Infrastructure.Models;

public class SnapshotEntry
{
    private SnapshotEntry() { } // For EF Core

    public SnapshotEntry(Guid aggregateId, string aggregateType, int aggregateVersion,
        string snapshotData, DateTime createdOn)
    {
        AggregateId = aggregateId;
        AggregateType = aggregateType;
        AggregateVersion = aggregateVersion;
        SnapshotData = snapshotData;
        CreatedOn = createdOn;
    }

    public Guid AggregateId { get; private set; }
    public string AggregateType { get; private set; } = null!;
    public int AggregateVersion { get; private set; }
    public string SnapshotData { get; private set; } = null!;
    public DateTime CreatedOn { get; private set; }
}