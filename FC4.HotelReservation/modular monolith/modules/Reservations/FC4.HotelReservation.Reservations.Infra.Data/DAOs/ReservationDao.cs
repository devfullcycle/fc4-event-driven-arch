using System.Data;
using Dapper;
using FC4.HotelReservation.Reservations.Application.Queries.Common;
using FC4.HotelReservation.Reservations.Domain.Enums;

namespace FC4.HotelReservation.Reservations.Infra.Data.DAOs;

public class ReservationDao(IDbConnection connection) : IReservationDao
{
    public async Task<IEnumerable<ReservationResult>> ListByGuestIdAsync(Guid guestId, CancellationToken cancellationToken)
    {
        const string sql = @"
            SELECT 
                id as Id,
                hotel_id as HotelId,
                room_type_id as RoomTypeId,
                stay_start_date as StartDate,
                stay_end_date as EndDate,
                status as Status,
                room_quantity as RoomQuantity,
                total_amount as Amount,
                total_currency as Currency,
                created_at as CreatedAt
            FROM reservations
            WHERE guest_id = @GuestId
            ORDER BY created_at DESC";
        
        var results = await connection.QueryAsync<ReservationOutputDto>(
            sql,
            new { GuestId = guestId });
        
        return results.Select(dto => new ReservationResult(
            dto.Id,
            dto.HotelId,
            dto.RoomTypeId,
            dto.StartDate,
            dto.EndDate,
            Enum.Parse<ReservationStatus>(dto.Status),
            dto.RoomQuantity,
            dto.Amount,
            dto.Currency,
            dto.CreatedAt));
        
    }
    
    private record ReservationOutputDto(
        Guid Id,
        Guid HotelId,
        Guid RoomTypeId,
        DateTime StartDate,
        DateTime EndDate,
        string Status,
        int RoomQuantity,
        decimal Amount,
        string Currency,
        DateTime CreatedAt);
}