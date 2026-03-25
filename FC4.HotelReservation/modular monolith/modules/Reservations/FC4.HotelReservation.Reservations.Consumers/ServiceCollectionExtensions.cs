using FC4.HotelReservation.Reservations.Consumers.Configuration;
using FC4.HotelReservation.Reservations.Consumers.Store;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace FC4.HotelReservation.Reservations.Consumers;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMongoDbReadDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var mongoSettings = configuration.GetSection("MongoDb")
            .Get<MongoDbSettings>() ?? new MongoDbSettings();

        services.AddSingleton<IMongoClient>(_ => new MongoClient(mongoSettings.ConnectionString));

        services.AddSingleton(sp =>
        {
            var client = sp.GetRequiredService<IMongoClient>();
            return client.GetDatabase(mongoSettings.DatabaseName);
        });

        services.AddScoped<IReservationReadStore, ReservationReadStore>();
        services.AddScoped<IInventoryReadStore, InventoryReadStore>();

        return services;
    }
}