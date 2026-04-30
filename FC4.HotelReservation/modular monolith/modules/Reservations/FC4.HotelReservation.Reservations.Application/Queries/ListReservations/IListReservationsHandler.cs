using FC4.HotelReservation.Reservations.Application.Queries.Common;
using MediatR;

namespace FC4.HotelReservation.Reservations.Application.Queries.ListReservations;

public interface IListReservationsHandler : IRequestHandler<ListReservationsQuery, IEnumerable<ReservationResult>>;