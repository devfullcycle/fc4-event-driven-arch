using FC4.HotelReservation.Reservations.Application.Queries.Common;
using FC4.HotelReservation.Reservations.Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FC4.HotelReservation.Reservations.Infra.Data.Models;

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
    
    public string HotelName { get; set; }
    
    public DateTime EndDate { get; set; }
    
    public int RoomQuantity { get; set; }
    
    public decimal Amount { get; set; }
    
    public string Currency { get; set; } = string.Empty;
    
    public string Status { get; set; } = "Pending";
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
    
    public ReservationResult ToReservationResult()
    {
        return new ReservationResult(
            ReservationId,
            HotelId,
            RoomTypeId,
            StartDate,
            EndDate,
            Enum.Parse<ReservationStatus>(Status),
            RoomQuantity,
            Amount,
            Currency,
            CreatedAt,
            HotelName);
    }
}