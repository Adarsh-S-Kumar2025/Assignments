using HotelBookingSystem.Data;
using HotelBookingSystem.DTOs.RoomType;
using HotelBookingSystem.Models;
using HotelBookingSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Services.Implementations
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly HotelBookingContext _db;
        public RoomTypeService(HotelBookingContext db) => _db = db;

        public async Task<RoomType> AddAsync(RoomTypeAddDto dto)
        {
            var type = new RoomType { TypeName = dto.TypeName, Description = dto.Description, Capacity = dto.Capacity };
            _db.RoomTypes.Add(type);
            await _db.SaveChangesAsync();
            return type;
        }

        public async Task<RoomType?> UpdateAsync(RoomTypeUpdateDto dto)
        {
            var type = await _db.RoomTypes.FindAsync(dto.Id);
            if (type == null) return null;
            type.TypeName = dto.TypeName; type.Description = dto.Description; type.Capacity = dto.Capacity;
            await _db.SaveChangesAsync();
            return type;
        }

        public Task<RoomType?> GetByIdAsync(int id) => _db.RoomTypes.FirstOrDefaultAsync(x => x.Id == id);
        public async Task DeleteAsync(int id)
        {
            var type = await _db.RoomTypes.FindAsync(id);
            if (type != null) { _db.RoomTypes.Remove(type); await _db.SaveChangesAsync(); }
        }

        public async Task<IReadOnlyList<RoomType>> ListAsync()
        {
            var list = await _db.RoomTypes.AsNoTracking().ToListAsync();
            return list.AsReadOnly();
        }
    }
}
