using FC4.HotelReservation.Reservations.Consumers.Store;
using Microsoft.Extensions.DependencyInjection;

namespace FC4.HotelReservation.Reservations.Consumers;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMongoDbReadDatabase(this IServiceCollection services)
    {
        services.AddScoped<IReservationReadStore, ReservationReadStore>();
        services.AddScoped<IInventoryReadStore, InventoryReadStore>();
        return services;
    }
}