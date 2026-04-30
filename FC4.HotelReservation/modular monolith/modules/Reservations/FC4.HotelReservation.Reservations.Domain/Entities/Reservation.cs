using Ardalis.GuardClauses;
using FC4.HotelReservation.Reservations.Domain.Enums;
using FC4.HotelReservation.Reservations.Domain.Events;
using FC4.HotelReservation.Reservations.Domain.ValueObjects;
using FC4.HotelReservation.Shared.Domain;

namespace FC4.HotelReservation.Reservations.Domain.Entities;

public class Reservation : EventSourced
{
    public Guid HotelId { get; private set; }
    public Guid RoomTypeId { get; private set; }
    public DateRange StayPeriod { get; private set; }
    public ReservationStatus Status { get; private set; }
    public Guid GuestId { get; private set; }
    public int RoomQuantity { get; private set; }
    public Money TotalAmount { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private Reservation()
    {
        Register<ReservationCreatedEvent>(OnReservationCreated);
        Register<ReservationCanceledEvent>(OnReservationCanceled);
        Register<ReservationPaidEvent>(OnReservationPaid);
        Register<ReservationRefundedEvent>(OnReservationRefunded);
    } // For EF Core

    internal Reservation(
        Guid id,
        Guid hotelId,
        Guid roomTypeId,
        DateRange stayPeriod,
        Guid guestId,
        int roomQuantity,
        Money totalAmount,
        ReservationStatus status,
        DateTime createdAt) : base(id)
    {
        HotelId = Guard.Against.Default(hotelId, nameof(hotelId));
        RoomTypeId = Guard.Against.Default(roomTypeId, nameof(roomTypeId));
        StayPeriod = Guard.Against.Null(stayPeriod, nameof(stayPeriod));
        GuestId = Guard.Against.Default(guestId, nameof(guestId));
        RoomQuantity = Guard.Against.NegativeOrZero(roomQuantity, nameof(roomQuantity));
        TotalAmount = Guard.Against.Null(totalAmount, nameof(totalAmount));
        Status = Guard.Against.EnumOutOfRange(status, nameof(status));
        CreatedAt = Guard.Against.Default(createdAt, nameof(createdAt));
    }

    public static Reservation Create(
        Guid hotelId,
        Guid roomTypeId,
        DateRange stayPeriod,
        Guid guestId,
        int roomQuantity,
        Money totalAmount)
    {
        Guard.Against.Default(hotelId, nameof(hotelId));
        Guard.Against.Default(roomTypeId, nameof(roomTypeId));
        Guard.Against.Null(stayPeriod, nameof(stayPeriod));
        Guard.Against.Default(guestId, nameof(guestId));
        Guard.Against.NegativeOrZero(roomQuantity, nameof(roomQuantity));
        Guard.Against.Null(totalAmount, nameof(totalAmount));
        var reservation = new Reservation();
        reservation.RaiseEvent(new ReservationCreatedEvent(
            Guid.NewGuid(), hotelId, roomTypeId, stayPeriod, guestId, roomQuantity, totalAmount));
        return reservation;
    }

    public void Cancel()
    {
        if (Status is ReservationStatus.Cancelled or ReservationStatus.Rejected)
            throw new InvalidOperationException("Reservation is already cancelled or rejected");

        RaiseEvent(new ReservationCanceledEvent(Id, HotelId, RoomTypeId, StayPeriod, RoomQuantity, ReservationStatus.Cancelled));
    }

    public void Reject()
    {
        if (Status != ReservationStatus.Pending)
            throw new InvalidOperationException("Can only reject pending reservations");

        RaiseEvent(new ReservationCanceledEvent(Id, HotelId, RoomTypeId, StayPeriod, RoomQuantity, ReservationStatus.Rejected));
    }

    public void MarkAsPaid()
    {
        if (Status is ReservationStatus.Cancelled or ReservationStatus.Rejected)
            throw new InvalidOperationException("Cannot mark cancelled or rejected reservation as paid");

        RaiseEvent(new ReservationPaidEvent(Id));
    }

    public void Refund()
    {
        if (Status != ReservationStatus.Paid)
            throw new InvalidOperationException("Can only refund paid reservations");

        RaiseEvent(new ReservationRefundedEvent(Id));
    }

    private void OnReservationCreated(ReservationCreatedEvent e)
    {
        Id = e.ReservationId;
        HotelId = e.HotelId;
        RoomTypeId = e.RoomTypeId;
        StayPeriod = e.StayPeriod;
        GuestId = e.GuestId;
        RoomQuantity = e.RoomQuantity;
        TotalAmount = e.Amount;
        Status = ReservationStatus.Pending;
        CreatedAt = e.OccuredOn;
    }

    private void OnReservationCanceled(ReservationCanceledEvent e)
    {
        Status = e.Status;
    }

    private void OnReservationPaid(ReservationPaidEvent e)
    {
        Status = ReservationStatus.Paid;
    }

    private void OnReservationRefunded(ReservationRefundedEvent e)
    {
        Status = ReservationStatus.Refunded;
    }
}