using FC4.HotelReservation.Shared.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FC4.HotelReservation.Shared.Infrastructure.Mappings;

public class SnapshotEntryConfiguration: IEntityTypeConfiguration<SnapshotEntry>
{
    public void Configure(EntityTypeBuilder<SnapshotEntry> builder)
    {
        builder.ToTable("snapshots");

        builder.HasKey(s => new { s.AggregateId, s.AggregateVersion });

        builder.Property(s => s.AggregateId)
            .HasColumnName("aggregate_id");

        builder.Property(s => s.AggregateType)
            .HasColumnName("aggregate_type")
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(s => s.AggregateVersion)
            .HasColumnName("aggregate_version")
            .IsRequired();

        builder.Property(s => s.SnapshotData)
            .HasColumnName("snapshot_data")
            .IsRequired();

        builder.Property(s => s.CreatedOn)
            .HasColumnName("created_on")
            .HasConversion(
                date => DateTime.SpecifyKind(date, DateTimeKind.Utc),
                date => DateTime.SpecifyKind(date, DateTimeKind.Utc))
            .IsRequired();
    }
}