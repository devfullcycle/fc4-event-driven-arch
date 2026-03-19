using FC4.HotelReservation.Reservations.Consumers.Models;
using FC4.HotelReservation.Reservations.Consumers.Store;
using FC4.HotelReservation.Reservations.Events.IntegrationEvents;
using MassTransit;

namespace FC4.HotelReservation.Reservations.Consumers.Consumers;

public class ReservationCreatedConsumer(
    IReservationReadStore store)
    : IConsumer<ReservationCreated>
{
    public async Task Consume(ConsumeContext<ReservationCreated> context)
    {
        var message = context.Message;
        var reservation = new ReservationModel
        {
            ReservationId = message.ReservationId,
            HotelId = message.HotelId,
            RoomTypeId = message.RoomTypeId,
            GuestId = message.GuestId,
            StartDate = message.StartDate,
            EndDate = message.EndDate,
            RoomQuantity = message.RoomQuantity,
            Amount = message.Amount,
            Currency = message.Currency,
            Status = "Pending",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await store.CreateOrUpdateReservationAsync(reservation, context.CancellationToken);
    }
}