using FC4.HotelReservation.Reservations.Application.Queries.Common;
using FC4.HotelReservation.Reservations.Domain.Repositories;

namespace FC4.HotelReservation.Reservations.Application.Queries.ListReservations;

public class ListReservationsHandler(IReservationRepository reservationRepository) : IListReservationsHandler
{
    public async Task<IEnumerable<ReservationResult>> Handle(
        ListReservationsQuery request,
        CancellationToken cancellationToken)
    {
        var reservations = await reservationRepository.GetByGuestIdAsync(request.GuestId, cancellationToken);
        return reservations.Select(ReservationResult.FromReservation);
    }
}