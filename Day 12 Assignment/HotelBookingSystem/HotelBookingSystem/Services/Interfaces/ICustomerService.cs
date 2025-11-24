using HotelBookingSystem.DTOs.Customer;
using HotelBookingSystem.Models;

namespace HotelBookingSystem.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> AddAsync(CustomerAddDto dto);
        Task<Customer?> UpdateAsync(CustomerUpdateDto dto);
        Task<Customer?> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task<IReadOnlyList<Customer>> ListAsync();
    }
}
