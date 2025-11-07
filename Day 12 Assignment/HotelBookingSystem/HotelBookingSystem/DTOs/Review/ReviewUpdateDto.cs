namespace HotelBookingSystem.DTOs.Review
{
    public record ReviewUpdateDto(
        int Id,
        int HotelId,
        int CustomerId,
        int Rating,
        string Comment
    );
}