namespace HotelBookingSystem.DTOs.Hotel
{
    public record HotelAddDto(
        string Name,
        string Address,
        string City,
        string Country,
        string PhoneNumber
    );
}