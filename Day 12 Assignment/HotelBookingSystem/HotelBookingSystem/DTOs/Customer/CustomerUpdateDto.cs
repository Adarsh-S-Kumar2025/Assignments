namespace HotelBookingSystem.DTOs.Customer
{
    public record CustomerUpdateDto(
        int Id,
        string FullName,
        string Email,
        string PhoneNumber,
        string IdProofNumber
    );
}