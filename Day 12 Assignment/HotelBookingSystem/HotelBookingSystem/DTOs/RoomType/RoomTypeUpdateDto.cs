namespace HotelBookingSystem.DTOs.RoomType
{
    public record RoomTypeUpdateDto(
        int Id,
        string TypeName,
        string Description,
        int Capacity
    );
}