using FC4.HotelReservation.Reservations.Application.Gateways.Models;

namespace FC4.HotelReservation.Reservations.Application.Gateways;

public interface ICatalogHotelService
{
    Task<HotelInfo> GetHotelInfoAsync(Guid hotelId, CancellationToken cancellationToken);
}


