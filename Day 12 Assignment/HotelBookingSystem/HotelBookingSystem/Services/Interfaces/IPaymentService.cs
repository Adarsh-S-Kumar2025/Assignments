using HotelBookingSystem.DTOs.Payment;
using HotelBookingSystem.Models;

namespace HotelBookingSystem.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<Payment> AddAsync(PaymentAddDto dto);
        Task<Payment?> UpdateAsync(PaymentUpdateDto dto);
        Task<Payment?> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task<IReadOnlyList<Payment>> ListAsync();
    }
}
