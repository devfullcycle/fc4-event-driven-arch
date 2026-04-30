namespace FC4.HotelReservation.Reservations.Infra.Data.Configuration;

public class MongoDbSettings
{
    public string ConnectionString { get; set; } = "mongodb://localhost:27017";
    public string DatabaseName { get; set; } = "hotel_reservation";
}