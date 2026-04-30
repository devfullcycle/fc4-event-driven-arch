using FC4.HotelReservation.Shared.Application.IntegrationEvents;

namespace FC4.HotelReservation.Reservations.Events.IntegrationEvents;

public class ReservationCreated(
    Guid reservationId,
    Guid hotelId,
    Guid roomTypeId,
    DateTime startDate,
    DateTime endDate,
    Guid guestId,
    int roomQuantity,
    decimal amount,
    string currency) : IntegrationEvent
{
    public Guid ReservationId { get; } = reservationId;
    public Guid HotelId { get; } = hotelId;
    public Guid RoomTypeId { get; } = roomTypeId;
    public DateTime StartDate { get; } = startDate;
    public DateTime EndDate { get; } = endDate;
    public Guid GuestId { get; } = guestId;
    public int RoomQuantity { get; } = roomQuantity;
    public decimal Amount { get; } = amount;
    public string Currency { get; } = currency;
}
