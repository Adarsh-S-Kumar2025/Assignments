namespace HotelBookingSystem.DTOs.Review
{
    public record ReviewAddDto(
        int HotelId,
        int CustomerId,
        int Rating, // 1-5
        string Comment
    );
}