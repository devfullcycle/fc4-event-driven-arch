using FC4.HotelReservation.Reservations.Domain.Entities;
using FC4.HotelReservation.Reservations.Domain.Repositories;
using FC4.HotelReservation.Shared.Infrastructure;
using FC4.HotelReservation.Shared.Infrastructure.EventStore;
using Microsoft.EntityFrameworkCore;

namespace FC4.HotelReservation.Reservations.Infra.Data.Repositories;

public class ReservationRepository(EventStoreRepository<Reservation> eventStore) : IReservationRepository
{
    public async Task<Reservation?> GetByIdAsync(Guid reservationId, CancellationToken cancellationToken)
    {
        return await eventStore.LoadFromEventsAsync(reservationId, cancellationToken);
    }
}