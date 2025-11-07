using HotelBookingSystem.Data;
using HotelBookingSystem.DTOs.Booking;
using HotelBookingSystem.Models;
using HotelBookingSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly HotelBookingContext _db;
        public BookingService(HotelBookingContext db) => _db = db;

        public async Task<Booking> AddAsync(BookingAddDto dto)
        {
            var booking = new Booking
            {
                CustomerId = dto.CustomerId,
                RoomId = dto.RoomId,
                CheckInDate = dto.CheckInDate,
                CheckOutDate = dto.CheckOutDate,
                Status = dto.Status,
                TotalAmount = 0 // calculate later
            };
            _db.Bookings.Add(booking);
            await _db.SaveChangesAsync();
            return booking;
        }

        public async Task<Booking?> UpdateAsync(BookingUpdateDto dto)
        {
            var b = await _db.Bookings.FindAsync(dto.Id);
            if (b == null) return null;
            b.CustomerId = dto.CustomerId; b.RoomId = dto.RoomId;
            b.CheckInDate = dto.CheckInDate; b.CheckOutDate = dto.CheckOutDate;
            b.Status = dto.Status; b.TotalAmount = dto.TotalAmount;
            await _db.SaveChangesAsync();
            return b;
        }

        public Task<Booking?> GetByIdAsync(int id) => _db.Bookings.FirstOrDefaultAsync(b => b.Id == id);

        public async Task DeleteAsync(int id)
        {
            var b = await _db.Bookings.FindAsync(id);
            if (b != null) { _db.Bookings.Remove(b); await _db.SaveChangesAsync(); }
        }

        public async Task<IReadOnlyList<Booking>> ListAsync()
        {
            var list = await _db.Bookings.AsNoTracking().ToListAsync();
            return list.AsReadOnly();
        }
    }
}
