using FC4.HotelReservation.Shared.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FC4.HotelReservation.Shared.Infrastructure.Mappings;

public class EventEntryConfiguration : IEntityTypeConfiguration<EventEntry>
{
    public void Configure(EntityTypeBuilder<EventEntry> builder)
    {
        builder.ToTable("event_store");

        builder.HasKey(e => e.EventId);
        builder.Property(e => e.EventId)
            .HasColumnName("event_id")
            .ValueGeneratedNever();

        builder.Property(e => e.AggregateId)
            .HasColumnName("aggregate_id")
            .IsRequired();
        
        builder.Property(e => e.AggregateVersion)
            .HasColumnName("aggregate_version")
            .IsRequired();

        builder.Property(e => e.EventType)
            .HasColumnName("event_type")
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(e => e.EventData)
            .HasColumnName("event_data")
            .IsRequired();

        builder.Property(e => e.OccurredOn)
            .HasColumnName("occurred_on")
            .HasConversion(
                date => DateTime.SpecifyKind(date, DateTimeKind.Utc),
                date => DateTime.SpecifyKind(date, DateTimeKind.Utc))
            .IsRequired();

        builder.HasIndex(e => new { e.AggregateId, e.AggregateVersion })
            .IsUnique()
            .HasDatabaseName("uix_event_store_aggregate_id_version");
    }
}