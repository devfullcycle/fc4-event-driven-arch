using FC4.HotelReservation.Catalog.Application.UseCases.Hotel.GetHotel;
using FC4.HotelReservation.Reservations.Application.Gateways;
using FC4.HotelReservation.Reservations.Application.Gateways.Models;
using MediatR;

namespace FC4.HotelReservation.Reservations.Adapters.Adapters;

public class CatalogHotelService(IMediator mediator) : ICatalogHotelService
{
    public async Task<HotelInfo> GetHotelInfoAsync(Guid hotelId, CancellationToken cancellationToken)
    {
        var hotel = await mediator.Send(new GetHotelInput(hotelId), cancellationToken);
        return new HotelInfo(
            hotel.Id,
            hotel.Name,
            hotel.Street,
            hotel.City,
            hotel.State,
            hotel.Country,
            hotel.ZipCode
        );
    }
}


