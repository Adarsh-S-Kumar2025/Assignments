namespace HotelBookingSystem.DTOs.Employee
{
    public record EmployeeAddDto(
        int HotelId,
        string FullName,
        string Role,
        string Email
    );
}