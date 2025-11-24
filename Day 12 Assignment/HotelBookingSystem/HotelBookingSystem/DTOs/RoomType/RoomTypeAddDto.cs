namespace HotelBookingSystem.DTOs.RoomType
{
    public record RoomTypeAddDto(
        string TypeName,
        string Description,
        int Capacity
    );
}