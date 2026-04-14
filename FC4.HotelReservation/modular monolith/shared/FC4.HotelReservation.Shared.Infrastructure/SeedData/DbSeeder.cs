using System.Text.Json;
using FC4.HotelReservation.Catalog.Domain.Entities;
using FC4.HotelReservation.Guests.Domain.Entities;
using FC4.HotelReservation.Shared.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FC4.HotelReservation.Shared.Infrastructure.SeedData;

public static class DbSeeder
{
    public static void SeedData(this ModelBuilder modelBuilder)
    {
        SeedHotels(modelBuilder);
        SeedRoomTypes(modelBuilder);
        SeedGuests(modelBuilder);
        SeedRoomTypeInventory(modelBuilder);
        SeedRoomTypeRates(modelBuilder);
    }

    private static void SeedHotels(ModelBuilder modelBuilder)
    {
        var hotelId = new Guid("11111111-1111-1111-1111-111111111111");
        
        modelBuilder.Entity<Hotel>().HasData(new
        {
            Id = hotelId,
            Name = "Grand Hotel Plaza"
        });

        // Seed do Address (owned entity)
        modelBuilder.Entity<Hotel>()
            .OwnsOne(h => h.Address)
            .HasData(new
            {
                HotelId = hotelId,
                Street = "123 Main Street",
                City = "New York",
                State = "NY",
                Country = "USA",
                ZipCode = "10001"
            });
    }

    private static void SeedRoomTypes(ModelBuilder modelBuilder)
    {
        var hotelId = new Guid("11111111-1111-1111-1111-111111111111");
        var roomTypeId = new Guid("11111111-1111-1111-1111-111111111111");

        modelBuilder.Entity<RoomType>().HasData(
            new
            {
                Id = roomTypeId,
                HotelId = hotelId,
                Description = "Standard Room"
            }
        );
    }

    private static void SeedGuests(ModelBuilder modelBuilder)
    {
        var guestId = new Guid("11111111-1111-1111-1111-111111111111");
        
        modelBuilder.Entity<Guest>().HasData(
            new
            {
                Id = guestId,
                FirstName = "John",
                LastName = "Doe"
            }
        );
        
        modelBuilder.Entity<Guest>()
            .OwnsOne(h => h.Email)
            .HasData(new
            {
                GuestId = guestId,
                Value = "john.doe@example.com"
            });
    }

    private static void SeedRoomTypeInventory(ModelBuilder modelBuilder)
    {
        var hotelId = new Guid("11111111-1111-1111-1111-111111111111");
        var roomTypeId = new Guid("11111111-1111-1111-1111-111111111111");
        
        var projections = new List<object>();
        var eventEntries = new List<object>();
        var startDate = new DateTime(2026, 3, 23);
        var occurredOn = new DateTime(2026, 3, 22, 0, 0, 0, DateTimeKind.Utc);
        
        for (int dayOffset = 0; dayOffset < 60; dayOffset++)
        {
            var currentDate = startDate.AddDays(dayOffset);
            var inventoryId = new Guid($"44444444-4444-4444-4444-{(dayOffset + 1):D12}");

            projections.Add(new
            {
                Id = inventoryId,
                RoomTypeId = roomTypeId,
                HotelId = hotelId,
                Date = currentDate,
            });

            // Seed RoomTypeInventoryCreatedEvent in the event store
            var eventId = new Guid($"55555555-5555-5555-5555-{(dayOffset + 1):D12}");
            var eventData = JsonSerializer.Serialize(new
            {
                InventoryId = inventoryId,
                HotelId = hotelId,
                RoomTypeId = roomTypeId,
                Date = currentDate,
                TotalInventory = 10,
                EventId = eventId,
                AggregateId = inventoryId,
                AggregateVersion = 0,
                OccuredOn = occurredOn
            });

            eventEntries.Add(new
            {
                EventId = eventId,
                AggregateId = inventoryId,
                AggregateVersion = 0,
                EventType = "RoomTypeInventoryCreatedEvent",
                EventData = eventData,
                OccurredOn = occurredOn
            });
        }

        modelBuilder.Entity<RoomTypeInventoryProjection>().HasData(projections.ToArray());
        modelBuilder.Entity<EventEntry>().HasData(eventEntries.ToArray());
    }

    private static void SeedRoomTypeRates(ModelBuilder modelBuilder)
    {
        var hotelId = new Guid("11111111-1111-1111-1111-111111111111");
        var roomTypeId = new Guid("11111111-1111-1111-1111-111111111111");
        
        var startDate = new DateTime(2026, 3, 23); // Data atual
        var baseRate = 150.00m; // Tarifa base de $150
        
        var rates = new List<object>();
        
        // Criar taxas para os próximos 60 dias
        for (int dayOffset = 0; dayOffset < 60; dayOffset++)
        {
            var currentDate = startDate.AddDays(dayOffset);
            
            rates.Add(new
            {
                Id = new Guid($"11111111-1111-1111-1111-{(dayOffset + 1):D12}"),
                RoomTypeId = roomTypeId,
                HotelId = hotelId,
                Date = currentDate
            });
        }

        modelBuilder.Entity<RoomTypeRate>().HasData(rates.ToArray());
        
        // Seed do Rate (owned entity Money)
        for (int dayOffset = 0; dayOffset < 60; dayOffset++)
        {
            var currentDate = startDate.AddDays(dayOffset);
            var rate = baseRate;
            
            // Aumentar tarifa nos fins de semana (sexta, sábado)
            if (currentDate.DayOfWeek == DayOfWeek.Friday || currentDate.DayOfWeek == DayOfWeek.Saturday)
            {
                rate = baseRate * 1.3m; // 30% mais caro
            }

            modelBuilder.Entity<RoomTypeRate>()
                .OwnsOne(r => r.Rate)
                .HasData(new
                {
                    RoomTypeRateId = new Guid($"11111111-1111-1111-1111-{(dayOffset + 1):D12}"),
                    Value = rate,
                    Currency = "USD"
                });
        }
    }
}
