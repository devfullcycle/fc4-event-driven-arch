using FC4.HotelReservation.Reservations.Domain.Enums;
using FC4.HotelReservation.Reservations.Domain.Events;
using FC4.HotelReservation.Reservations.Events.IntegrationEvents;
using MassTransit;
using MediatR;

namespace FC4.HotelReservation.Reservations.Application.EventHandlers;

public class ReservationRefundedEventHandler(IPublishEndpoint publishEndpoint)
    : INotificationHandler<ReservationRefundedEvent>
{
    public async Task Handle(ReservationRefundedEvent notification, CancellationToken cancellationToken)
    {
        var integrationEvent = new ReservationStatusChanged(
            notification.ReservationId,
            ReservationStatus.Refunded.ToString("G"));
        await publishEndpoint.Publish(integrationEvent, cancellationToken);
    }
}