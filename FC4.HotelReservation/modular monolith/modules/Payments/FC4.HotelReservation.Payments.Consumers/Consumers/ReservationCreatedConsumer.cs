using FC4.HotelReservation.Payments.Application.UseCases.Payment.CreatePendingPayment;
using FC4.HotelReservation.Reservations.Events.IntegrationEvents;
using MassTransit;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FC4.HotelReservation.Payments.Consumers.Consumers;

public class ReservationCreatedConsumer(IServiceProvider provider) : IConsumer<ReservationCreated>
{
    public async Task Consume(ConsumeContext<ReservationCreated> context)
    {
        using var scope = provider.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        await mediator.Send(new CreatePendingPaymentInput(
                context.Message.ReservationId,
                context.Message.Amount,
                context.Message.Currency),
            context.CancellationToken);
    }
}