using HotelBookingSystem.Data;
using HotelBookingSystem.DTOs.Customer;
using HotelBookingSystem.Models;
using HotelBookingSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly HotelBookingContext _db;
        public CustomerService(HotelBookingContext db) => _db = db;

        public async Task<Customer> AddAsync(CustomerAddDto dto)
        {
            var customer = new Customer
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                IdProofNumber = dto.IdProofNumber
            };
            _db.Customers.Add(customer);
            await _db.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer?> UpdateAsync(CustomerUpdateDto dto)
        {
            var customer = await _db.Customers.FindAsync(dto.Id);
            if (customer == null) return null;
            customer.FullName = dto.FullName; customer.Email = dto.Email;
            customer.PhoneNumber = dto.PhoneNumber; customer.IdProofNumber = dto.IdProofNumber;
            await _db.SaveChangesAsync();
            return customer;
        }

        public Task<Customer?> GetByIdAsync(int id) => _db.Customers.FirstOrDefaultAsync(c => c.Id == id);

        public async Task DeleteAsync(int id)
        {
            var c = await _db.Customers.FindAsync(id);
            if (c != null) { _db.Customers.Remove(c); await _db.SaveChangesAsync(); }
        }

        public async Task<IReadOnlyList<Customer>> ListAsync()
        {
            var list = await _db.Customers.AsNoTracking().ToListAsync();
            return list.AsReadOnly();
        }
    }
}
