using HotelBookingSystem.Models;

namespace HotelBookingSystem.DTOs.Room
{
    public record RoomUpdateDto(
        int Id,
        string RoomNumber,
        int HotelId,
        int RoomTypeId,
        RoomStatus Status,
        decimal PricePerNight
    );
}