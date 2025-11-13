using HotelBookingSystem.DTOs.Room;
using HotelBookingSystem.Models;

namespace HotelBookingSystem.Services.Interfaces
{
    public interface IRoomService
    {
        Task<Room> AddAsync(RoomAddDto dto);
        Task<Room?> UpdateAsync(RoomUpdateDto dto);
        Task<Room?> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task<IReadOnlyList<Room>> ListAsync();
    }
}