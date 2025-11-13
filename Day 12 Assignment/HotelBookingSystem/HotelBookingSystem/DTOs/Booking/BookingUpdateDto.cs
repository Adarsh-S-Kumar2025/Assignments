using HotelBookingSystem.Models;

namespace HotelBookingSystem.DTOs.Booking
{
    public record BookingUpdateDto(
        int Id,
        int CustomerId,
        int RoomId,
        DateTime CheckInDate,
        DateTime CheckOutDate,
        BookingStatus Status,
        decimal TotalAmount
    );
}