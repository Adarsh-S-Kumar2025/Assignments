namespace HotelBookingSystem.DTOs.Customer
{
    public record CustomerAddDto(
        string FullName,
        string Email,
        string PhoneNumber,
        string IdProofNumber
    );
}