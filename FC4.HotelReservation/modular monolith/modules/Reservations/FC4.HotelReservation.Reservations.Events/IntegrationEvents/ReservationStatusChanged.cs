using FC4.HotelReservation.Shared.Application.IntegrationEvents;

namespace FC4.HotelReservation.Reservations.Events.IntegrationEvents;

public class ReservationStatusChanged(Guid reservationId, string status) : IntegrationEvent
{
    public Guid ReservationId { get; } = reservationId;
    public string Status { get; } = status;
}