using HotelBookingSystem.Data;
using HotelBookingSystem.DTOs.Employee;
using HotelBookingSystem.Models;
using HotelBookingSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HotelBookingContext _db;
        public EmployeeService(HotelBookingContext db) => _db = db;

        public async Task<Employee> AddAsync(EmployeeAddDto dto)
        {
            var emp = new Employee
            {
                HotelId = dto.HotelId,
                FullName = dto.FullName,
                Role = dto.Role,
                Email = dto.Email
            };
            _db.Employees.Add(emp);
            await _db.SaveChangesAsync();
            return emp;
        }

        public async Task<Employee?> UpdateAsync(EmployeeUpdateDto dto)
        {
            var emp = await _db.Employees.FindAsync(dto.Id);
            if (emp == null) return null;
            emp.HotelId = dto.HotelId; emp.FullName = dto.FullName;
            emp.Role = dto.Role; emp.Email = dto.Email;
            await _db.SaveChangesAsync();
            return emp;
        }

        public Task<Employee?> GetByIdAsync(int id) => _db.Employees.FirstOrDefaultAsync(e => e.Id == id);

        public async Task DeleteAsync(int id)
        {
            var e = await _db.Employees.FindAsync(id);
            if (e != null) { _db.Employees.Remove(e); await _db.SaveChangesAsync(); }
        }

        public async Task<IReadOnlyList<Employee>> ListAsync()
        {
            var list = await _db.Employees.AsNoTracking().ToListAsync();
            return list.AsReadOnly();
        }
    }
}
