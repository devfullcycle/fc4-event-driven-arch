namespace FC4.HotelReservation.Reservations.Application.Gateways.Models;

public record HotelInfo(
    Guid Id,
    string Name,
    string Street,
    string City,
    string State,
    string Country,
    string ZipCode
);

