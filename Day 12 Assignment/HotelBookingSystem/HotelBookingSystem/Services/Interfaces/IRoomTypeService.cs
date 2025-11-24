using HotelBookingSystem.DTOs.RoomType;
using HotelBookingSystem.Models;

namespace HotelBookingSystem.Services.Interfaces
{
    public interface IRoomTypeService
    {
        Task<RoomType> AddAsync(RoomTypeAddDto dto);
        Task<RoomType?> UpdateAsync(RoomTypeUpdateDto dto);
        Task<RoomType?> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task<IReadOnlyList<RoomType>> ListAsync();
    }
}
