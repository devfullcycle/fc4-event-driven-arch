using FC4.HotelReservation.Reservations.Domain.ValueObjects;
using FC4.HotelReservation.Shared.Domain;

namespace FC4.HotelReservation.Reservations.Domain.Events;

public class ReservationCreatedEvent(
    Guid reservationId,
    Guid hotelId,
    Guid roomTypeId,
    DateRange stayPeriod,
    Guid guestId,
    int roomQuantity,
    Money totalAmount) : DomainEvent
{
    public Guid ReservationId { get; } = reservationId;
    public Guid HotelId { get; } = hotelId;
    public Guid RoomTypeId { get; } = roomTypeId;
    public DateRange StayPeriod { get; } = stayPeriod;
    public Guid GuestId { get; } = guestId;
    public int RoomQuantity { get; } = roomQuantity;
    public Money Amount { get; } = totalAmount;
}