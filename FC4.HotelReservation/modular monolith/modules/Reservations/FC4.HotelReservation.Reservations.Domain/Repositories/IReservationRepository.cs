using FC4.HotelReservation.Reservations.Domain.Entities;

namespace FC4.HotelReservation.Reservations.Domain.Repositories;

public interface IReservationRepository
{
    Task<Reservation?> GetByIdAsync(Guid reservationId, CancellationToken cancellationToken);
}