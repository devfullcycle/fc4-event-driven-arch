namespace FC4.HotelReservation.Shared.Infrastructure.Models;

public class RoomTypeInventoryProjection
{
    public Guid Id { get; set; }
    public Guid HotelId { get; set; }
    public Guid RoomTypeId { get; set; }
    public DateTime Date { get; set; }
}