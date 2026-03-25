using FC4.HotelReservation.Reservations.Consumers.Models;
using MongoDB.Driver;

namespace FC4.HotelReservation.Reservations.Consumers.Store;

public interface IInventoryReadStore
{
    Task CreateOrUpdateInventoryAsync(InventoryModel inventory, CancellationToken cancellationToken = default);
}

public class InventoryReadStore(IMongoDatabase database) : IInventoryReadStore
{
    private readonly IMongoCollection<InventoryModel> _inventory = database.GetCollection<InventoryModel>("inventory");

    public async Task CreateOrUpdateInventoryAsync(InventoryModel inventory, CancellationToken cancellationToken = default)
    {
        var filter = Builders<InventoryModel>.Filter.Eq(i => i.InventoryId, inventory.InventoryId);
        
        var options = new ReplaceOptions { IsUpsert = true };
        
        await _inventory.ReplaceOneAsync(filter, inventory, options, cancellationToken);
    }
}