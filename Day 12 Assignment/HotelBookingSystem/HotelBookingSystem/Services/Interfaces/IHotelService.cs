using HotelBookingSystem.DTOs.Hotel;
using HotelBookingSystem.Models;

namespace HotelBookingSystem.Services.Interfaces
{
    public interface IHotelService
    {
        Task<Hotel> AddAsync(HotelAddDto dto);
        Task<Hotel?> UpdateAsync(HotelUpdateDto dto);
        Task<Hotel?> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task<IReadOnlyList<Hotel>> ListAsync();
    }
}
