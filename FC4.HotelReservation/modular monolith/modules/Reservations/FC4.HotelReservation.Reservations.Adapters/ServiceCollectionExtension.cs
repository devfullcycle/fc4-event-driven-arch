using FC4.HotelReservation.Reservations.Adapters.Adapters;
using FC4.HotelReservation.Reservations.Application.Gateways;
using Microsoft.Extensions.DependencyInjection;

namespace FC4.HotelReservation.Reservations.Adapters;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddReservationsAdapters(
        this IServiceCollection services)
    {
        services.AddScoped<ICatalogRateService, CatalogRateService>();
        services.AddScoped<ICatalogHotelService, CatalogHotelService>();
        return services;
    }
}