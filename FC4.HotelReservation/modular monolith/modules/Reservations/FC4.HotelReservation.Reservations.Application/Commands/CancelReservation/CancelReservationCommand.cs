using MediatR;

namespace FC4.HotelReservation.Reservations.Application.Commands.CancelReservation;

public record CancelReservationCommand(Guid ReservationId) : IRequest;