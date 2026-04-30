using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FC4.HotelReservation.Reservations.Consumers.Models;

public class InventoryModel
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid InventoryId { get; set; }
    
    [BsonRepresentation(BsonType.String)]
    public Guid HotelId { get; set; }
    
    [BsonRepresentation(BsonType.String)]
    public Guid RoomTypeId { get; set; }
    
    public DateTime Date { get; set; }
    
    public int Quantity { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
}