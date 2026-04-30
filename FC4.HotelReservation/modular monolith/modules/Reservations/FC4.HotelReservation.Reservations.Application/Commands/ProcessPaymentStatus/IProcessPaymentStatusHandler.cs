using MediatR;

namespace FC4.HotelReservation.Reservations.Application.Commands.ProcessPaymentStatus;

public interface IProcessPaymentStatusHandler : IRequestHandler<ProcessPaymentStatusCommand>;