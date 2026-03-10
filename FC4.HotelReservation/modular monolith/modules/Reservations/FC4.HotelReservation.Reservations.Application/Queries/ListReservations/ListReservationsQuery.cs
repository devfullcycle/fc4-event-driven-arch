using FC4.HotelReservation.Reservations.Application.Queries.Common;
using MediatR;

namespace FC4.HotelReservation.Reservations.Application.Queries.ListReservations;

public record ListReservationsQuery(Guid GuestId) : IRequest<IEnumerable<ReservationResult>>;