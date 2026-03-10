using FC4.HotelReservation.Reservations.Domain.Enums;

namespace FC4.HotelReservation.Reservations.Application.Queries.Common;

public record ReservationResult(
    Guid Id,
    Guid HotelId,
    Guid RoomTypeId,
    DateTime StartDate,
    DateTime EndDate,
    ReservationStatus Status,
    int RoomQuantity,
    decimal Amount,
    string Currency,
    DateTime CreatedAt)
{
    public static ReservationResult FromReservation(Domain.Entities.Reservation reservation)
    {
        return new ReservationResult(
            reservation.Id,
            reservation.HotelId,
            reservation.RoomTypeId,
            reservation.StayPeriod.StartDate,
            reservation.StayPeriod.EndDate,
            reservation.Status,
            reservation.RoomQuantity,
            reservation.TotalAmount.Value,
            reservation.TotalAmount.Currency,
            reservation.CreatedAt);
    }
}