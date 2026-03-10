using FC4.HotelReservation.Reservations.Application.Queries.Common;
using MediatR;

namespace FC4.HotelReservation.Reservations.Application.UseCases.Reservation.GetReservation;

public interface IGetReservation: IRequestHandler<GetReservationInput, ReservationResult>;