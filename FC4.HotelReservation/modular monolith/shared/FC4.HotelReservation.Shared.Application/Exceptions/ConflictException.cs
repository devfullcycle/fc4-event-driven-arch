namespace FC4.HotelReservation.Shared.Application.Exceptions;

public class ConflictException(string message, Exception innerException) : Exception(message, innerException);