using FC4.HotelReservation.Reservations.Consumers.Models;

namespace FC4.HotelReservation.Reservations.Consumers.Store;

public interface IInventoryReadStore
{
    Task CreateOrUpdateInventoryAsync(InventoryModel inventory, CancellationToken cancellationToken = default);
}