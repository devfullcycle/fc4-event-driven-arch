using MediatR;

namespace FC4.HotelReservation.Reservations.Application.Commands.ProcessPaymentStatus;

public record ProcessPaymentStatusCommand(Guid PaymentId, Guid ReservationId, PaymentStatus PaymentStatus)
    : IRequest;

public enum PaymentStatus
{
    Pending = 1,
    Processing = 2,
    Completed = 3,
    Failed = 4,
    Refunded = 5
}