using HotelBookingSystem.Models;

namespace HotelBookingSystem.DTOs.Room
{
    public record RoomAddDto(
        string RoomNumber,
        int HotelId,
        int RoomTypeId,
        RoomStatus Status,
        decimal PricePerNight
    );
}