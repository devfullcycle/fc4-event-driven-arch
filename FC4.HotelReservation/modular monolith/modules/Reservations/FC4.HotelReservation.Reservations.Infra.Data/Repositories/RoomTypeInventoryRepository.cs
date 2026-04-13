using FC4.HotelReservation.Reservations.Domain.Entities;
using FC4.HotelReservation.Reservations.Domain.Repositories;
using FC4.HotelReservation.Reservations.Domain.ValueObjects;
using FC4.HotelReservation.Shared.Infrastructure;
using FC4.HotelReservation.Shared.Infrastructure.EventStore;
using Microsoft.EntityFrameworkCore;

namespace FC4.HotelReservation.Reservations.Infra.Data.Repositories;

public class RoomTypeInventoryRepository(HotelDbContext context,
    EventStoreRepository<RoomTypeInventory> eventStoreRepository) : IRoomTypeInventoryRepository
{
    public async Task<List<RoomTypeInventory>> GetInventoryForPeriodAsync(
        Guid hotelId, 
        Guid roomTypeId, 
        DateRange period, 
        CancellationToken cancellationToken)
    {
        // Sync projection
        // Transactional read-model
        // | HotelId | RoomTypeId | Date | Id |
        var dates = period.GetDates().Select(d => d.ToString("yyyy-MM-dd")).ToList();
        var datesLiteral = string.Join(", ", dates.Select(d => $"'{d}'::date"));
        
        var sql = $@"SELECT * FROM room_type_inventory_projections
                    WHERE hotel_id = {{0}}
                      AND room_type_id = {{1}}
                      AND date IN ({datesLiteral})";
        
        var projections = await context.RoomTypeInventoryProjections
            .FromSqlRaw(sql, hotelId, roomTypeId)
            .AsTracking()
            .ToListAsync(cancellationToken);
        
        var inventories = new List<RoomTypeInventory>();
        foreach (var projection in projections)
        {
            var inventory = await eventStoreRepository.LoadFromEventsAsync(projection.Id, cancellationToken);
            if (inventory != null)
                inventories.Add(inventory);
        }
        
        return  inventories;
    }

}