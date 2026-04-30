using FC4.HotelReservation.Reservations.Domain.Events;
using FC4.HotelReservation.Reservations.Domain.Repositories;
using FC4.HotelReservation.Reservations.Events.IntegrationEvents;
using MassTransit;
using MediatR;

namespace FC4.HotelReservation.Reservations.Application.EventHandlers;

public class ReservationCanceledEventHandler(
    IRoomTypeInventoryRepository roomTypeInventoryRepository,
    IPublishEndpoint publishEndpoint)
    : INotificationHandler<ReservationCanceledEvent>
{
    public async Task Handle(ReservationCanceledEvent notification, CancellationToken cancellationToken)
    {
        var inventories = await roomTypeInventoryRepository.GetInventoryForPeriodAsync(
            notification.HotelId, notification.RoomTypeId, notification.StayPeriod, cancellationToken);
        
        foreach (var inventory in inventories)
        {
            inventory.ReleaseRooms(notification.RoomQuantity);
        }
        
        var integrationEvent = new ReservationStatusChanged(
            notification.ReservationId, notification.Status.ToString("G"));
        await publishEndpoint.Publish(integrationEvent, cancellationToken);
    }
}