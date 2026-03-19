using FC4.HotelReservation.Reservations.Consumers.Models;

namespace FC4.HotelReservation.Reservations.Consumers.Store;

public interface IReservationReadStore
{
    Task CreateOrUpdateReservationAsync(ReservationModel reservation, CancellationToken cancellationToken = default);
    Task UpdateReservationStatusAsync(Guid reservationId, string status, CancellationToken cancellationToken = default);
}