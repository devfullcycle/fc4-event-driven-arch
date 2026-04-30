using FC4.HotelReservation.Reservations.Domain.ValueObjects;
using MediatR;

namespace FC4.HotelReservation.Reservations.Application.Commands.CreateReservation;

public record CreateReservationCommand(
    Guid HotelId,
    Guid RoomTypeId,
    DateTime StartDate,
    DateTime EndDate,
    Guid GuestId,
    int RoomQuantity
) : IRequest<CreateReservationResult>
{
    public Domain.Entities.Reservation ToReservation(Money totalAmount)
    {
        var stayPeriod = new DateRange(StartDate, EndDate);
        return Domain.Entities.Reservation.Create(HotelId, RoomTypeId, stayPeriod, GuestId, RoomQuantity, totalAmount);
    }
}
