using FC4.HotelReservation.Reservations.Consumers.Models;
using FC4.HotelReservation.Reservations.Consumers.Store;
using FC4.HotelReservation.Reservations.Events.IntegrationEvents;
using MassTransit;

namespace FC4.HotelReservation.Reservations.Consumers.Consumers;

public class InventoryChangedConsumer(
    IInventoryReadStore store)
    : IConsumer<InventoryChanged>
{
    public async Task Consume(ConsumeContext<InventoryChanged> context)
    {
        var message = context.Message;

        var inventory = new InventoryModel
        {
            InventoryId = message.InventoryId,
            HotelId = message.HotelId,
            RoomTypeId = message.RoomTypeId,
            Date = message.Date,
            Quantity = message.Quantity,
            UpdatedAt = DateTime.UtcNow
        };

        await store.CreateOrUpdateInventoryAsync(inventory, context.CancellationToken);
    }
}