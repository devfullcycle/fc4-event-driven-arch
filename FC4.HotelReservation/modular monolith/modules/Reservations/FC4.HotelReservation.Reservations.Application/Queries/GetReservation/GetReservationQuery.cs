using FC4.HotelReservation.Reservations.Application.Queries.Common;
using MediatR;

namespace FC4.HotelReservation.Reservations.Application.Queries.GetReservation;

public record GetReservationQuery(Guid ReservationId) : IRequest<ReservationResult>;