using HotelBookingSystem.Data;
using HotelBookingSystem.DTOs.Payment;
using HotelBookingSystem.Models;
using HotelBookingSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly HotelBookingContext _db;
        public PaymentService(HotelBookingContext db) => _db = db;

        public async Task<Payment> AddAsync(PaymentAddDto dto)
        {
            var payment = new Payment
            {
                BookingId = dto.BookingId,
                Amount = dto.Amount,
                Method = dto.Method,
                Status = dto.Status,
                PaymentDate = DateTime.UtcNow
            };
            _db.Payments.Add(payment);
            await _db.SaveChangesAsync();
            return payment;
        }

        public async Task<Payment?> UpdateAsync(PaymentUpdateDto dto)
        {
            var p = await _db.Payments.FindAsync(dto.Id);
            if (p == null) return null;
            p.Amount = dto.Amount; p.Method = dto.Method; p.Status = dto.Status;
            await _db.SaveChangesAsync();
            return p;
        }

        public Task<Payment?> GetByIdAsync(int id) => _db.Payments.FirstOrDefaultAsync(p => p.Id == id);

        public async Task DeleteAsync(int id)
        {
            var p = await _db.Payments.FindAsync(id);
            if (p != null) { _db.Payments.Remove(p); await _db.SaveChangesAsync(); }
        }

        public async Task<IReadOnlyList<Payment>> ListAsync()
        {
            var list = await _db.Payments.AsNoTracking().ToListAsync();
            return list.AsReadOnly();
        }
    }
}
