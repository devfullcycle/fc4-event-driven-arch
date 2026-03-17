using FC4.HotelReservation.Reservations.Application.Queries.Common;

namespace FC4.HotelReservation.Reservations.Application.Queries.ListReservations;

public class ListReservationsHandler(IReservationDao reservationDao) : IListReservationsHandler
{
    public async Task<IEnumerable<ReservationResult>> Handle(
        ListReservationsQuery request,
        CancellationToken cancellationToken) 
        => await reservationDao.ListByGuestIdAsync(request.GuestId, cancellationToken);
}