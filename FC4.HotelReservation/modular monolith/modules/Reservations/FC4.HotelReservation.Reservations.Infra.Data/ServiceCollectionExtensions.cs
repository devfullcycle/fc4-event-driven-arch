using System.Data;
using FC4.HotelReservation.Reservations.Application.Queries.Common;
using FC4.HotelReservation.Reservations.Domain.Repositories;
using FC4.HotelReservation.Reservations.Infra.Data.Configuration;
using FC4.HotelReservation.Reservations.Infra.Data.DAOs;
using FC4.HotelReservation.Reservations.Infra.Data.Repositories;
using FC4.HotelReservation.Shared.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace FC4.HotelReservation.Reservations.Infra.Data;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddReservationsRepositories(this IServiceCollection services)
    {
        return services
            .AddScoped<IReservationRepository, ReservationRepository>()
            .AddScoped<IReservationGuestRepository, ReservationGuestRepository>()
            .AddScoped<IRoomTypeInventoryRepository, RoomTypeInventoryRepository>()
            .AddScoped<IReservationDao, ReservationDao>()
            .AddScoped<IDbConnection>(sp => sp.GetRequiredService<HotelDbContext>().Database.GetDbConnection());
    }

    public static IServiceCollection AddReservationsMongoDb(
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
        
        return services;
    }
}