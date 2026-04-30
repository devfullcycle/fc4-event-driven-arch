using FC4.HotelReservation.Reservations.Domain.Events;
using FC4.HotelReservation.Reservations.Events.IntegrationEvents;
using MassTransit;
using MediatR;

namespace FC4.HotelReservation.Reservations.Application.EventHandlers;

public class RoomsReservedEventHandler(IPublishEndpoint publishEndpoint)
    : INotificationHandler<RoomsReservedEvent>
{
    public async Task Handle(RoomsReservedEvent notification, CancellationToken cancellationToken)
    {
        var integrationEvent = new InventoryChanged(
            notification.InventoryId,
            notification.HotelId,
            notification.RoomTypeId,
            notification.Date,
            notification.Quantity);
        await publishEndpoint.Publish(integrationEvent, cancellationToken);
    }
}
