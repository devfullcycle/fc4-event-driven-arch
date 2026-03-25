using FC4.HotelReservation.Reservations.Application.Queries.Common;
using FC4.HotelReservation.Reservations.Infra.Data.Models;
using MongoDB.Driver;

namespace FC4.HotelReservation.Reservations.Infra.Data.DAOs;

public class ReservationDao(IMongoDatabase database) : IReservationDao
{
    private readonly IMongoCollection<ReservationModel> _reservations =
        database.GetCollection<ReservationModel>("reservations");
    
    public async Task<IEnumerable<ReservationResult>> ListByGuestIdAsync(Guid guestId,
        CancellationToken cancellationToken)
    {
        var filter = Builders<ReservationModel>.Filter.Eq(r => r.GuestId, guestId);
        var sort = Builders<ReservationModel>.Sort.Descending(r => r.CreatedAt);
        
        var results = await _reservations
            .Find(filter)
            .Sort(sort)
            .ToListAsync(cancellationToken);
        
        return results.Select(model => model.ToReservationResult());
    }

    public async Task<ReservationResult?> GetByIdAsync(Guid reservationId, CancellationToken cancellationToken)
    {
        var filter = Builders<ReservationModel>.Filter.Eq(r => r.ReservationId, reservationId);

        var model = await _reservations
            .Find(filter)
            .FirstOrDefaultAsync(cancellationToken);

        return model?.ToReservationResult();
    }
}