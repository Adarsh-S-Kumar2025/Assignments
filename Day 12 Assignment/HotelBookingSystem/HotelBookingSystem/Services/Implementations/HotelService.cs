using HotelBookingSystem.Data;
using HotelBookingSystem.DTOs.Hotel;
using HotelBookingSystem.Models;
using HotelBookingSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Services.Implementations
{
    public class HotelService : IHotelService
    {
        private readonly HotelBookingContext _db;
        public HotelService(HotelBookingContext db) => _db = db;

        public async Task<Hotel> AddAsync(HotelAddDto dto)
        {
            var hotel = new Hotel
            {
                Name = dto.Name,
                Address = dto.Address,
                City = dto.City,
                Country = dto.Country,
                PhoneNumber = dto.PhoneNumber
            };
            _db.Hotels.Add(hotel);
            await _db.SaveChangesAsync();
            return hotel;
        }

        public async Task<Hotel?> UpdateAsync(HotelUpdateDto dto)
        {
            var hotel = await _db.Hotels.FindAsync(dto.Id);
            if (hotel == null) return null;

            hotel.Name = dto.Name;
            hotel.Address = dto.Address;
            hotel.City = dto.City;
            hotel.Country = dto.Country;
            hotel.PhoneNumber = dto.PhoneNumber;

            await _db.SaveChangesAsync();
            return hotel;
        }

        public Task<Hotel?> GetByIdAsync(int id) => _db.Hotels.FirstOrDefaultAsync(h => h.Id == id);

        public async Task DeleteAsync(int id)
        {
            var hotel = await _db.Hotels.FindAsync(id);
            if (hotel != null)
            {
                _db.Hotels.Remove(hotel);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IReadOnlyList<Hotel>> ListAsync()
        {
            var list = await _db.Hotels.AsNoTracking().ToListAsync();
            return list.AsReadOnly(); // ← Perfect!
        }
    }
}
