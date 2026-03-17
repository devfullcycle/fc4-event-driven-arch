using FC4.HotelReservation.Reservations.Domain.Entities;
using FC4.HotelReservation.Reservations.Domain.Repositories;
using FC4.HotelReservation.Shared.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FC4.HotelReservation.Reservations.Infra.Data.Repositories;

public class ReservationRepository(HotelDbContext context) : IReservationRepository
{
    public async Task<Reservation?> GetByIdAsync(Guid reservationId, CancellationToken cancellationToken)
    {
        return await context.Reservations
            .FirstOrDefaultAsync(r => r.Id == reservationId, cancellationToken);
    }

    public async Task CreateAsync(Reservation reservation, CancellationToken cancellationToken)
    {
        await context.Reservations.AddAsync(reservation, cancellationToken);
    }

    public Task UpdateAsync(Reservation reservation, CancellationToken cancellationToken)
    {
        context.Reservations.Update(reservation);
        return Task.CompletedTask;
    }
}