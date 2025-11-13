namespace HotelBookingSystem.DTOs.Employee
{
    public record EmployeeUpdateDto(
        int Id,
        int HotelId,
        string FullName,
        string Role,
        string Email
    );
}