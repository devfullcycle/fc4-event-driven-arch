using System.Text.Json;
using FC4.HotelReservation.Catalog.Domain.Entities;
using FC4.HotelReservation.Reservations.Domain.Entities;
using FC4.HotelReservation.Reservations.Domain.Enums;
using FC4.HotelReservation.Reservations.Domain.Repositories;
using FC4.HotelReservation.Reservations.Domain.ValueObjects;
using FC4.HotelReservation.Shared.Infrastructure;
using FC4.HotelReservation.Shared.Domain;
using FC4.HotelReservation.Shared.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using static FC4.HotelReservation.IntegrationTests.DataBuilders.HotelBuilder;
using static FC4.HotelReservation.IntegrationTests.DataBuilders.RoomBuilder;
using static FC4.HotelReservation.IntegrationTests.DataBuilders.RoomTypeBuilder;
using static FC4.HotelReservation.IntegrationTests.DataBuilders.ReservationBuilder;
using static FC4.HotelReservation.IntegrationTests.DataBuilders.PaymentBuilder;
using static FC4.HotelReservation.IntegrationTests.DataBuilders.GuestBuilder;
using static FC4.HotelReservation.IntegrationTests.DataBuilders.RoomTypeRateBuilder;
using static FC4.HotelReservation.IntegrationTests.DataBuilders.RoomTypeInventoryBuilder;
using DomainEntities = FC4.HotelReservation.Reservations.Domain.Entities;

namespace FC4.HotelReservation.IntegrationTests;

public partial class WebApiFixture
{
    public async Task CleanDatabaseAsync()
    {
        using var scope = Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<HotelDbContext>();

        await dbContext.Database.ExecuteSqlRawAsync("DELETE FROM payments");
        await dbContext.Database.ExecuteSqlRawAsync("DELETE FROM room_type_rates");
        await dbContext.Database.ExecuteSqlRawAsync("DELETE FROM room_type_inventory_projections");
        await dbContext.Database.ExecuteSqlRawAsync("DELETE FROM rooms");
        await dbContext.Database.ExecuteSqlRawAsync("DELETE FROM room_types");
        await dbContext.Database.ExecuteSqlRawAsync("DELETE FROM hotels");
        await dbContext.Database.ExecuteSqlRawAsync("DELETE FROM guests");
    }

    private async Task<T> AddToDatabaseAsync<T>(T entity) where T : Entity
    {
        using var scope = Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<HotelDbContext>();

        await dbContext.Set<T>().AddAsync(entity);
        await dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<Catalog.Domain.Entities.Hotel> CreateHotelInDatabaseAsync(
        Catalog.Domain.Entities.Hotel? hotel = null)
    {
        hotel ??= AHotel().Build();
        return await AddToDatabaseAsync(hotel);
    }

    public async Task<Catalog.Domain.Entities.Room> CreateRoomInDatabaseAsync(Catalog.Domain.Entities.Room? room = null)
    {
        if (room is null)
        {
            var hotel = await CreateHotelInDatabaseAsync();
            var roomType = await CreateRoomTypeInDatabaseAsync();
            room = ARoom()
                .WithRoomTypeId(roomType.Id)
                .WithHotelId(hotel.Id)
                .Build();
        }

        return await AddToDatabaseAsync(room);
    }

    public async Task<RoomType> CreateRoomTypeInDatabaseAsync(RoomType? roomType = null)
    {
        roomType ??= ARoomType().Build();
        return await AddToDatabaseAsync(roomType);
    }

    public async Task<Reservations.Domain.Entities.Reservation> CreateReservationInDatabaseAsync(
        Reservations.Domain.Entities.Reservation? reservation = null)
    {
        if (reservation is null)
        {
            var hotel = await CreateHotelInDatabaseAsync();
            var roomType = await CreateRoomTypeInDatabaseAsync();
            var guest = await CreateGuestInDatabaseAsync();
            reservation = AReservation()
                .WithHotelId(hotel.Id)
                .WithRoomTypeId(roomType.Id)
                .WithGuestId(guest.Id)
                .Build();
        }

        
        using var scope = Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<HotelDbContext>();

        var version = 0;
        var now = DateTime.UtcNow;

        // ReservationCreatedEvent (version 0)
        var createdEventData = JsonSerializer.Serialize(new
        {
            ReservationId = reservation.Id,
            reservation.HotelId,
            reservation.RoomTypeId,
            StayPeriod = new { reservation.StayPeriod.StartDate, reservation.StayPeriod.EndDate },
            reservation.GuestId,
            reservation.RoomQuantity,
            Amount = new { reservation.TotalAmount.Value, reservation.TotalAmount.Currency },
            EventId = Guid.NewGuid(),
            AggregateId = reservation.Id,
            AggregateVersion = version,
            OccuredOn = now
        });

        dbContext.EventStore.Add(new EventEntry(
            Guid.NewGuid(), reservation.Id, version,
            "ReservationCreatedEvent", createdEventData, now));

        // Add status transition events based on the desired status
        switch (reservation.Status)
        {
            case ReservationStatus.Paid:
                version++;
                var paidEventData = JsonSerializer.Serialize(new
                {
                    ReservationId = reservation.Id,
                    EventId = Guid.NewGuid(),
                    AggregateId = reservation.Id,
                    AggregateVersion = version,
                    OccuredOn = now
                });
                dbContext.EventStore.Add(new EventEntry(
                    Guid.NewGuid(), reservation.Id, version,
                    "ReservationPaidEvent", paidEventData, now));
                break;

            case ReservationStatus.Cancelled:
                version++;
                var cancelledEventData = JsonSerializer.Serialize(new
                {
                    ReservationId = reservation.Id,
                    reservation.HotelId,
                    reservation.RoomTypeId,
                    StayPeriod = new { reservation.StayPeriod.StartDate, reservation.StayPeriod.EndDate },
                    reservation.RoomQuantity,
                    Status = ReservationStatus.Cancelled,
                    EventId = Guid.NewGuid(),
                    AggregateId = reservation.Id,
                    AggregateVersion = version,
                    OccuredOn = now
                });
                dbContext.EventStore.Add(new EventEntry(
                    Guid.NewGuid(), reservation.Id, version,
                    "ReservationCanceledEvent", cancelledEventData, now));
                break;

            case ReservationStatus.Rejected:
                version++;
                var rejectedEventData = JsonSerializer.Serialize(new
                {
                    ReservationId = reservation.Id,
                    reservation.HotelId,
                    reservation.RoomTypeId,
                    StayPeriod = new { reservation.StayPeriod.StartDate, reservation.StayPeriod.EndDate },
                    reservation.RoomQuantity,
                    Status = ReservationStatus.Rejected,
                    EventId = Guid.NewGuid(),
                    AggregateId = reservation.Id,
                    AggregateVersion = version,
                    OccuredOn = now
                });
                dbContext.EventStore.Add(new EventEntry(
                    Guid.NewGuid(), reservation.Id, version,
                    "ReservationCanceledEvent", rejectedEventData, now));
                break;

            case ReservationStatus.Refunded:
                version++;
                var paidForRefundData = JsonSerializer.Serialize(new
                {
                    ReservationId = reservation.Id,
                    EventId = Guid.NewGuid(),
                    AggregateId = reservation.Id,
                    AggregateVersion = version,
                    OccuredOn = now
                });
                dbContext.EventStore.Add(new EventEntry(
                    Guid.NewGuid(), reservation.Id, version,
                    "ReservationPaidEvent", paidForRefundData, now));

                version++;
                var refundedEventData = JsonSerializer.Serialize(new
                {
                    ReservationId = reservation.Id,
                    EventId = Guid.NewGuid(),
                    AggregateId = reservation.Id,
                    AggregateVersion = version,
                    OccuredOn = now
                });
                dbContext.EventStore.Add(new EventEntry(
                    Guid.NewGuid(), reservation.Id, version,
                    "ReservationRefundedEvent", refundedEventData, now));
                break;
        }

        await dbContext.SaveChangesAsync();
        return reservation;
    }

    public async Task<Payments.Domain.Entities.Payment> CreatePaymentInDatabaseAsync(
        Payments.Domain.Entities.Payment? payment = null)
    {
        payment ??= APayment().Build();
        return await AddToDatabaseAsync(payment);
    }

    public async Task<Guests.Domain.Entities.Guest> CreateGuestInDatabaseAsync(
        Guests.Domain.Entities.Guest? guest = null)
    {
        guest ??= AGuest().Build();
        return await AddToDatabaseAsync(guest);
    }

    public async Task<RoomTypeRate> CreateRoomTypeRateInDatabaseAsync(RoomTypeRate? rate = null)
    {
        rate ??= ARoomTypeRate().Build();
        return await AddToDatabaseAsync(rate);
    }

    public async Task<RoomTypeInventory> CreateRoomTypeInventoryInDatabaseAsync(RoomTypeInventory? inventory = null)
    {
        inventory ??= ARoomTypeInventory().Build();
        
        using var scope = Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<HotelDbContext>();

        // Insert projection
        var projection = new RoomTypeInventoryProjection
        {
            Id = inventory.Id,
            HotelId = inventory.HotelId,
            RoomTypeId = inventory.RoomTypeId,
            Date = inventory.Date
        };
        await dbContext.RoomTypeInventoryProjections.AddAsync(projection);

        // Insert RoomTypeInventoryCreatedEvent in the event store
        var eventData = JsonSerializer.Serialize(new
        {
            InventoryId = inventory.Id,
            inventory.HotelId,
            inventory.RoomTypeId,
            inventory.Date,
            inventory.TotalInventory,
            EventId = Guid.NewGuid(),
            AggregateId = inventory.Id,
            AggregateVersion = 0,
            OccuredOn = DateTime.UtcNow
        });

        dbContext.EventStore.Add(new EventEntry(
            Guid.NewGuid(),
            inventory.Id,
            0,
            "RoomTypeInventoryCreatedEvent",
            eventData,
            DateTime.UtcNow));

        // If there are reserved rooms, also insert a RoomsReservedEvent
        if (inventory.TotalReserved > 0)
        {
            var reservedEventData = JsonSerializer.Serialize(new
            {
                InventoryId = inventory.Id,
                inventory.HotelId,
                inventory.RoomTypeId,
                inventory.Date,
                Quantity = inventory.TotalReserved,
                EventId = Guid.NewGuid(),
                AggregateId = inventory.Id,
                AggregateVersion = 1,
                OccuredOn = DateTime.UtcNow
            });

            dbContext.EventStore.Add(new EventEntry(
                Guid.NewGuid(),
                inventory.Id,
                1,
                "RoomsReservedEvent",
                reservedEventData,
                DateTime.UtcNow));
        }

        await dbContext.SaveChangesAsync();
        return inventory;
    }

    public async Task<Payments.Domain.Entities.Payment?> GetPaymentByReservationIdAsync(Guid reservationId)
    {
        using var scope = Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<HotelDbContext>();
        return await dbContext.Payments.FirstOrDefaultAsync(p => p.ReservationId == reservationId);
    }

    public async Task<List<RoomTypeInventory>> GetRoomTypeInventoriesAsync(Guid hotelId, Guid roomTypeId,
        DateRange period)
    {
        using var scope = Services.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<IRoomTypeInventoryRepository>();
        return await repository.GetInventoryForPeriodAsync(hotelId, roomTypeId, period, CancellationToken.None);
    }


    public async Task<Catalog.Domain.Entities.Hotel?> GetHotelByIdAsync(Guid hotelId)
    {
        using var scope = Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<HotelDbContext>();
        return await dbContext.Hotels.FirstOrDefaultAsync(h => h.Id == hotelId);
    }

    public async Task<Catalog.Domain.Entities.Room?> GetRoomByIdAsync(Guid roomId)
    {
        using var scope = Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<HotelDbContext>();
        return await dbContext.Rooms.FirstOrDefaultAsync(r => r.Id == roomId);
    }

    public async Task<Guests.Domain.Entities.Guest?> GetGuestByIdAsync(Guid hotelId)
    {
        using var scope = Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<HotelDbContext>();
        return await dbContext.Guests.FirstOrDefaultAsync(h => h.Id == hotelId);
    }

    public async Task<Reservations.Domain.Entities.Reservation?> GetReservationByIdAsync(Guid reservationId)
    {
        using var scope = Services.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<IReservationRepository>();
        return await repository.GetByIdAsync(reservationId, CancellationToken.None);
    }

    public async Task<Payments.Domain.Entities.Payment?> GetPaymentByIdAsync(Guid paymentId)
    {
        using var scope = Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<HotelDbContext>();
        return await dbContext.Payments.FirstOrDefaultAsync(p => p.Id == paymentId);
    }

    public async Task<List<DomainEntities.Reservation>> GetReservationsByGuestIdAsync(Guid guestId)
    {
        using var scope = Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<HotelDbContext>();
        var domainEvents = (await dbContext.EventStore.ToListAsync()).Select(e => e.ToDomainEvent());

        return domainEvents
            .GroupBy(e => e.AggregateId)
            .Select(events =>
            {
                var reservation = CreateReservation();
                reservation.Load(events);
                return reservation;
            })
            .Where(r => r.GuestId == guestId)
            .ToList();
        
        DomainEntities.Reservation CreateReservation()
            => (DomainEntities.Reservation)
                Activator.CreateInstance(typeof(DomainEntities.Reservation), nonPublic: true)!;
    }

    public async Task<RoomTypeInventory?> GetRoomTypeInventoryAsync(Guid hotelId, Guid roomTypeId, DateTime startDate)
    {
        using var scope = Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<IRoomTypeInventoryRepository>();

        var period = new DateRange(startDate, startDate.AddDays(1));
        return (await dbContext.GetInventoryForPeriodAsync(hotelId, roomTypeId, period, CancellationToken.None))
            .SingleOrDefault();
    }
}