using FC4.HotelReservation.Reservations.Application.Queries.Common;
using MediatR;

namespace FC4.HotelReservation.Reservations.Application.Queries.GetReservation;

public interface IGetReservationHandler : IRequestHandler<GetReservationQuery, ReservationResult>;