using FC4.HotelReservation.Reservations.Domain.Entities;
using FC4.HotelReservation.Shared.Application;
using FC4.HotelReservation.Shared.Infrastructure.EventStore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FC4.HotelReservation.Shared.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<EventStoreRepository<Reservation>>();
        services.AddScoped<EventStoreRepository<RoomTypeInventory>>();
        return services
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .AddDbContext<HotelDbContext>((serviceProvider, options) =>
            {
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                options.UseNpgsql(configuration.GetConnectionString("HotelReservationDb"));
                options.EnableSensitiveDataLogging();
                options.LogTo(Console.WriteLine, LogLevel.Information);
            });
    }
}