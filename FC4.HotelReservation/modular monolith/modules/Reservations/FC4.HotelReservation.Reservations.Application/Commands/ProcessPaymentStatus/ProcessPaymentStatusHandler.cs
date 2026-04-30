using FC4.HotelReservation.Reservations.Domain.Repositories;
using FC4.HotelReservation.Shared.Application;

namespace FC4.HotelReservation.Reservations.Application.Commands.ProcessPaymentStatus;

public class ProcessPaymentStatusHandler(
    IReservationRepository reservationRepository,
    IUnitOfWork unitOfWork): IProcessPaymentStatusHandler
{
    public async Task Handle(ProcessPaymentStatusCommand request, CancellationToken cancellationToken)
    {
        var reservation = await reservationRepository.GetByIdAsync(request.ReservationId, cancellationToken)
                          ?? throw new InvalidOperationException("Reservation not found");

        switch (request.PaymentStatus)
        {
            case PaymentStatus.Completed:
                reservation.MarkAsPaid();
                break;
            case PaymentStatus.Failed:
                reservation.Reject();
                break;
            case PaymentStatus.Refunded:
                reservation.Cancel();
                break;
            case PaymentStatus.Pending:
            case PaymentStatus.Processing:
            default:
                return;
        }

        await unitOfWork.CommitAsync(cancellationToken);
    }
}