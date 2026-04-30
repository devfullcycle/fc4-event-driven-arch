using MediatR;

namespace FC4.HotelReservation.Reservations.Application.Commands.CancelReservation;

public interface ICancelReservationHandler: IRequestHandler<CancelReservationCommand>;