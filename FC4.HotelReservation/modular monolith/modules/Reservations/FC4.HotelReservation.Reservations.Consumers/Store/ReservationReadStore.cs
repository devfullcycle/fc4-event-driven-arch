using FC4.HotelReservation.Reservations.Consumers.Models;
using MongoDB.Driver;

namespace FC4.HotelReservation.Reservations.Consumers.Store;

public interface IReservationReadStore
{
    Task CreateOrUpdateReservationAsync(ReservationModel reservation, CancellationToken cancellationToken = default);
    Task UpdateReservationStatusAsync(Guid reservationId, string status, CancellationToken cancellationToken = default);
}

public class ReservationReadStore(IMongoDatabase database) : IReservationReadStore
{
    private readonly IMongoCollection<ReservationModel> _reservations = database.GetCollection<ReservationModel>("reservations");

    public async Task CreateOrUpdateReservationAsync(ReservationModel reservation, CancellationToken cancellationToken = default)
    {
        var filter = Builders<ReservationModel>.Filter.Eq(r => r.ReservationId, reservation.ReservationId);
        
        var options = new ReplaceOptions { IsUpsert = true };
        
        await _reservations.ReplaceOneAsync(filter, reservation, options, cancellationToken);
    }

    public async Task UpdateReservationStatusAsync(Guid reservationId, string status, CancellationToken cancellationToken = default)
    {
        var filter = Builders<ReservationModel>.Filter.Eq(r => r.ReservationId, reservationId);
        
        var update = Builders<ReservationModel>.Update
            .Set(r => r.Status, status)
            .Set(r => r.UpdatedAt, DateTime.UtcNow);
        
        await _reservations.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);
    }
}