using FC4.HotelReservation.Reservations.Domain.Repositories;
using FC4.HotelReservation.Shared.Application;
using FC4.HotelReservation.Shared.Application.Exceptions;

namespace FC4.HotelReservation.Reservations.Application.Commands.CancelReservation;

public class CancelReservationHandler(IReservationRepository reservationRepository, IUnitOfWork unitOfWork) : ICancelReservationHandler
{
    public async Task Handle(CancelReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = await reservationRepository.GetByIdAsync(request.ReservationId, cancellationToken)
                          ?? throw new NotFoundException("Reservation not found");
        reservation.Cancel();
        await reservationRepository.UpdateAsync(reservation, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);
    }
}