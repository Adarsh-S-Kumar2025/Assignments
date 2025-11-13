using HotelBookingSystem.Data;
using HotelBookingSystem.DTOs.Room;
using HotelBookingSystem.Models;
using HotelBookingSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Services.Implementations
{
    public class RoomService : IRoomService
    {
        private readonly HotelBookingContext _db;
        public RoomService(HotelBookingContext db) => _db = db;

        public async Task<Room> AddAsync(RoomAddDto dto)
        {
            var room = new Room
            {
                RoomNumber = dto.RoomNumber,
                HotelId = dto.HotelId,
                RoomTypeId = dto.RoomTypeId,
                Status = dto.Status,
                PricePerNight = dto.PricePerNight
            };
            _db.Rooms.Add(room);
            await _db.SaveChangesAsync();
            return room;
        }

        public async Task<Room?> UpdateAsync(RoomUpdateDto dto)
        {
            var room = await _db.Rooms.FindAsync(dto.Id);
            if (room == null) return null;

            room.RoomNumber = dto.RoomNumber;
            room.HotelId = dto.HotelId;
            room.RoomTypeId = dto.RoomTypeId;
            room.Status = dto.Status;
            room.PricePerNight = dto.PricePerNight;

            await _db.SaveChangesAsync();
            return room;
        }

        public Task<Room?> GetByIdAsync(int id)
            => _db.Rooms.FirstOrDefaultAsync(r => r.Id == id);

        public async Task DeleteAsync(int id)
        {
            var room = await _db.Rooms.FindAsync(id);
            if (room != null)
            {
                _db.Rooms.Remove(room);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IReadOnlyList<Room>> ListAsync()
        {
            var rooms = await _db.Rooms.AsNoTracking().ToListAsync();
            return rooms.AsReadOnly();
        }
    }
}