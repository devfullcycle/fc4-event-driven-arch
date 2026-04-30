using FC4.HotelReservation.Shared.Application.IntegrationEvents;

namespace FC4.HotelReservation.Reservations.Events.IntegrationEvents;

public class InventoryChanged(
    Guid inventoryId,
    Guid hotelId,
    Guid roomTypeId,
    DateTime date,
    int quantity) : IntegrationEvent
{
    public Guid InventoryId { get; } = inventoryId;
    public Guid HotelId { get; } = hotelId;
    public Guid RoomTypeId { get; } = roomTypeId;
    public DateTime Date { get; } = date;
    public int Quantity { get; } = quantity;
}