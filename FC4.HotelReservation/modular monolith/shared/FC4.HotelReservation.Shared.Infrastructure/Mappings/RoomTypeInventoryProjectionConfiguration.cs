using FC4.HotelReservation.Catalog.Domain.Entities;
using FC4.HotelReservation.Reservations.Domain.Entities;
using FC4.HotelReservation.Shared.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FC4.HotelReservation.Shared.Infrastructure.Mappings;

public class RoomTypeInventoryProjectionConfiguration : IEntityTypeConfiguration<RoomTypeInventoryProjection>
{
    public void Configure(EntityTypeBuilder<RoomTypeInventoryProjection> builder)
    {
        builder.ToTable("room_type_inventory_projections");
        
        builder.HasKey(rti => rti.Id);
        builder.Property(rti => rti.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();
            
        builder.Property(rti => rti.HotelId)
            .HasColumnName("hotel_id")
            .IsRequired();
            
        builder.Property(rti => rti.RoomTypeId)
            .HasColumnName("room_type_id")
            .IsRequired();
            
        builder.Property(rti => rti.Date)
            .HasColumnName("date")
            .HasConversion(date => DateTime.SpecifyKind(date, DateTimeKind.Utc),
                date => DateTime.SpecifyKind(date, DateTimeKind.Utc))
            .IsRequired();
         
        builder.HasOne<Hotel>()
            .WithMany()
            .HasForeignKey(rti => rti.HotelId)
            .HasConstraintName("fk_room_type_inventories_hotels");
            
        builder.HasOne<RoomType>()
            .WithMany()
            .HasForeignKey(rti => rti.RoomTypeId)
            .HasConstraintName("fk_room_type_inventories_room_types");
        
        builder.HasIndex(rti => new { rti.HotelId, rti.RoomTypeId, rti.Date })
            .IsUnique();
    }
}