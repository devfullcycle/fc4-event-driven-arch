using FC4.HotelReservation.Reservations.Application.Queries.Common;
using FC4.HotelReservation.Shared.Application.Exceptions;

namespace FC4.HotelReservation.Reservations.Application.Queries.GetReservation;

public class GetReservationHandler(IReservationDao reservationDao) : IGetReservationHandler
{
    public async Task<ReservationResult> Handle(GetReservationQuery request, CancellationToken cancellationToken)
        => await reservationDao.GetByIdAsync(request.ReservationId, cancellationToken)
           ?? throw new NotFoundException("Reservation not found");
}