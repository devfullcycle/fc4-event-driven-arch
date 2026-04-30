using FC4.HotelReservation.Shared.Domain;

namespace FC4.HotelReservation.Reservations.Domain.Events;

public class RoomTypeInventoryCreatedEvent(
    Guid inventoryId,
    Guid hotelId,
    Guid roomTypeId,
    DateTime date,
    int totalInventory) : DomainEvent
{
    public Guid InventoryId { get; } = inventoryId;
    public Guid HotelId { get; } = hotelId;
    public Guid RoomTypeId { get; } = roomTypeId;
    public DateTime Date { get; } = date;
    public int TotalInventory { get; } = totalInventory;
}