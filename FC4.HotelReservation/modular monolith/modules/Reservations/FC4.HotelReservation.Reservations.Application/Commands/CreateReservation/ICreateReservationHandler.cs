using MediatR;

namespace FC4.HotelReservation.Reservations.Application.Commands.CreateReservation;

public interface ICreateReservationHandler: IRequestHandler<CreateReservationCommand, CreateReservationResult>;