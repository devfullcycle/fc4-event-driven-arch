using FC4.HotelReservation.Reservations.Consumers.Store;
using FC4.HotelReservation.Reservations.Events.IntegrationEvents;
using MassTransit;

namespace FC4.HotelReservation.Reservations.Consumers.Consumers;

public class ReservationStatusChangedConsumer(IReservationReadStore store)
    : IConsumer<ReservationStatusChanged>
{
    public async Task Consume(ConsumeContext<ReservationStatusChanged> context)
    {
        var message = context.Message;
        await store.UpdateReservationStatusAsync(
            message.ReservationId, 
            message.Status, 
            context.CancellationToken);
    }
}