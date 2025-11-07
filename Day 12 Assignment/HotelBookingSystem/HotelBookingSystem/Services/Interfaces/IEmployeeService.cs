using HotelBookingSystem.DTOs.Employee;
using HotelBookingSystem.Models;

namespace HotelBookingSystem.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee> AddAsync(EmployeeAddDto dto);
        Task<Employee?> UpdateAsync(EmployeeUpdateDto dto);
        Task<Employee?> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task<IReadOnlyList<Employee>> ListAsync();
    }
}
