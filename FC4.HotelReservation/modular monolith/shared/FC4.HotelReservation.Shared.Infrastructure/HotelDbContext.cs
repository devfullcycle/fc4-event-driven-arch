using FC4.HotelReservation.Catalog.Domain.Entities;
using FC4.HotelReservation.Guests.Domain.Entities;
using FC4.HotelReservation.Shared.Infrastructure.Mappings;
using FC4.HotelReservation.Shared.Infrastructure.SeedData;
using FC4.HotelReservation.Payments.Domain.Entities;
using FC4.HotelReservation.Reservations.Domain.Entities;
using FC4.HotelReservation.Shared.Infrastructure.Models;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace FC4.HotelReservation.Shared.Infrastructure;

public class HotelDbContext(DbContextOptions<HotelDbContext> options) : DbContext(options)
{
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<RoomType> RoomTypes { get; set; }
    public DbSet<RoomTypeInventoryProjection> RoomTypeInventoryProjections { get; set; }
    public DbSet<RoomTypeRate> RoomTypeRates { get; set; }
    public DbSet<EventEntry> EventStore { get; set; }
    public DbSet<SnapshotEntry> Snapshots { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GuestConfiguration());
        modelBuilder.ApplyConfiguration(new HotelConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentConfiguration());
        modelBuilder.ApplyConfiguration(new RoomConfiguration());
        modelBuilder.ApplyConfiguration(new RoomTypeConfiguration());
        modelBuilder.ApplyConfiguration(new RoomTypeInventoryProjectionConfiguration());
        modelBuilder.ApplyConfiguration(new RoomTypeRateConfiguration());
        modelBuilder.ApplyConfiguration(new EventEntryConfiguration());
        modelBuilder.ApplyConfiguration(new SnapshotEntryConfiguration());

        modelBuilder.AddInboxStateEntity();
        modelBuilder.AddOutboxMessageEntity();
        modelBuilder.AddOutboxStateEntity();

        // Seed data
        modelBuilder.SeedData();

        base.OnModelCreating(modelBuilder);
    }
}