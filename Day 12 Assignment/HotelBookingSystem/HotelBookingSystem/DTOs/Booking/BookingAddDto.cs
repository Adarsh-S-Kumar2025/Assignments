using HotelBookingSystem.Models;

namespace HotelBookingSystem.DTOs.Booking
{
    public record BookingAddDto(
        int CustomerId,
        int RoomId,
        DateTime CheckInDate,
        DateTime CheckOutDate,
        BookingStatus Status = BookingStatus.Pending
    );
}