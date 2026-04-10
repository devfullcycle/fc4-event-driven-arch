using Ardalis.GuardClauses;
using FC4.HotelReservation.Reservations.Domain.Events;
using FC4.HotelReservation.Shared.Domain;

namespace FC4.HotelReservation.Reservations.Domain.Entities;

public class RoomTypeInventory : EventSourced
{
    public Guid HotelId { get; private set; }
    public Guid RoomTypeId { get; private set; }
    public DateTime Date { get; private set; }
    public int TotalInventory { get; private set; }
    public int TotalReserved { get; private set; }

    private RoomTypeInventory()
    {
    } // For EF Core

    internal RoomTypeInventory(
        Guid id,
        Guid hotelId,
        Guid roomTypeId,
        DateTime date,
        int totalInventory,
        int totalReserved) : base(id)
    {
        HotelId = Guard.Against.Default(hotelId, nameof(hotelId));
        RoomTypeId = Guard.Against.Default(roomTypeId, nameof(roomTypeId));
        Date = Guard.Against.Default(date, nameof(date));
        TotalInventory = Guard.Against.Negative(totalInventory, nameof(totalInventory));
        TotalReserved = Guard.Against.Negative(totalReserved, nameof(totalReserved));
    }
    
    public static RoomTypeInventory Create(
        Guid hotelId,
        Guid roomTypeId,
        DateTime date,
        int totalInventory)
    {
        Guard.Against.Default(hotelId, nameof(hotelId));
        Guard.Against.Default(roomTypeId, nameof(roomTypeId));
        Guard.Against.Default(date, nameof(date));
        Guard.Against.Negative(totalInventory, nameof(totalInventory));
        var roomTypeInventory = new RoomTypeInventory();
        roomTypeInventory.RaiseEvent(new RoomTypeInventoryCreatedEvent(
            Guid.NewGuid(),
            hotelId,
            roomTypeId,
            date,
            totalInventory));
        return roomTypeInventory;
    }

    public int AvailableInventory => TotalInventory - TotalReserved;

    public bool CanReserve(int quantity)
    {
        return AvailableInventory >= quantity;
    }

    public void ReserveRooms(int quantity)
    {
        Guard.Against.NegativeOrZero(quantity, nameof(quantity));

        if (!CanReserve(quantity))
            throw new InvalidOperationException("Insufficient inventory available");

        RaiseEvent(new RoomsReservedEvent(
            Id,
            HotelId,
            RoomTypeId,
            Date,
            quantity));
    }

    public void ReleaseRooms(int quantity)
    {
        Guard.Against.NegativeOrZero(quantity, nameof(quantity));

        if (quantity > TotalReserved)
            throw new InvalidOperationException("Cannot release more rooms than reserved");

        RaiseEvent(new RoomsReleasedEvent(
            Id,
            HotelId,
            RoomTypeId,
            Date,
            quantity));
    }

    protected override void Apply(DomainEvent domainEvent)
    {
        switch (domainEvent)
        {
            case RoomTypeInventoryCreatedEvent e:
                Id = e.InventoryId;
                HotelId = e.HotelId;
                RoomTypeId = e.RoomTypeId;
                Date = e.Date;
                TotalInventory = e.TotalInventory;
                TotalReserved = 0;
                break;
            case RoomsReservedEvent e:
                TotalReserved += e.Quantity;
                break;
            case RoomsReleasedEvent e:
                TotalReserved -= e.Quantity;
                break;
            default:
                throw new InvalidOperationException($"Unknown event type: {domainEvent.GetType().Name}");
        }
    }
}