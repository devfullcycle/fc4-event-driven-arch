using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FC4.HotelReservation.Reservations.Consumers.Models;

public class ReservationModel
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid ReservationId { get; set; }
    
    [BsonRepresentation(BsonType.String)]
    public Guid HotelId { get; set; }
    
    [BsonRepresentation(BsonType.String)]
    public Guid RoomTypeId { get; set; }
    
    [BsonRepresentation(BsonType.String)]
    public Guid GuestId { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
    
    public int RoomQuantity { get; set; }
    
    public decimal Amount { get; set; }
    
    public string Currency { get; set; } = string.Empty;
    
    public string Status { get; set; } = "Pending";
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
}