using FC4.HotelReservation.Payments.Events.IntegrationEvents;
using FC4.HotelReservation.Reservations.Application.Commands.ProcessPaymentStatus;
using MassTransit;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FC4.HotelReservation.Reservations.Consumers.Consumers;

public class PaymentStatusChangedConsumer(IServiceProvider provider) : IConsumer<PaymentStatusChanged>
{
    public async Task Consume(ConsumeContext<PaymentStatusChanged> context)
    {
        using var scope = provider.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        await mediator.Send(new ProcessPaymentStatusCommand(
                context.Message.PaymentId,
                context.Message.ReservationId,
                (PaymentStatus)context.Message.PaymentStatus),
            context.CancellationToken);
    }
}