namespace HotelBookingSystem.DTOs.Hotel
{
    public record HotelUpdateDto(
        int Id,
        string Name,
        string Address,
        string City,
        string Country,
        string PhoneNumber
    );
}