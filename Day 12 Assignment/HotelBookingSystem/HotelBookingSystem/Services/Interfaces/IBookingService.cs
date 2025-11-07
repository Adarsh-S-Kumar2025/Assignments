using HotelBookingSystem.DTOs.Booking;
using HotelBookingSystem.Models;

namespace HotelBookingSystem.Services.Interfaces
{
    public interface IBookingService
    {
        Task<Booking> AddAsync(BookingAddDto dto);
        Task<Booking?> UpdateAsync(BookingUpdateDto dto);
        Task<Booking?> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task<IReadOnlyList<Booking>> ListAsync();
    }
}
