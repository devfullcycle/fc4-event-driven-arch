using FC4.HotelReservation.Shared.Domain;

namespace FC4.HotelReservation.Reservations.Domain.Events;

public class ReservationRefundedEvent(Guid reservationId) : DomainEvent
{
    public Guid ReservationId { get; } = reservationId;
}