using FC4.HotelReservation.Reservations.Domain.Entities;
using FC4.HotelReservation.Reservations.Domain.Repositories;
using FC4.HotelReservation.Reservations.Domain.ValueObjects;
using FC4.HotelReservation.Shared.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FC4.HotelReservation.Reservations.Infra.Data.Repositories;

public class RoomTypeInventoryRepository(HotelDbContext context) : IRoomTypeInventoryRepository
{
    public async Task<List<RoomTypeInventory>> GetInventoryForPeriodAsync(
        Guid hotelId, 
        Guid roomTypeId, 
        DateRange period, 
        CancellationToken cancellationToken)
    {
        var dates = period.GetDates().Select(d => d.ToString("yyyy-MM-dd")).ToList();
        var datesLiteral = string.Join(", ", dates.Select(d => $"'{d}'::date"));
        
        var sql = $@"SELECT * FROM room_type_inventory
                    WHERE hotel_id = {{0}}
                      AND room_type_id = {{1}}
                      AND date IN ({datesLiteral})";
        
        return await context.RoomTypeInventories
            .FromSqlRaw(sql, hotelId, roomTypeId)
            .AsTracking()
            .ToListAsync(cancellationToken);
    }

}