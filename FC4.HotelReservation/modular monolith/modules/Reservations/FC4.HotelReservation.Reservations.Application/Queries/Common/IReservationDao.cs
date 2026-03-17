namespace FC4.HotelReservation.Reservations.Application.Queries.Common;

public interface IReservationDao
{
    Task<IEnumerable<ReservationResult>> ListByGuestIdAsync(Guid guestId, CancellationToken cancellationToken);
}