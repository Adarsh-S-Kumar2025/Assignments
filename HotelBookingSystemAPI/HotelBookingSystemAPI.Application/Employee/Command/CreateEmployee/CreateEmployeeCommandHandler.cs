using MediatR;
using HotelBookingSystemAPI.Infrastructure.Data;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystemAPI.Application.Employee.Command.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
    {
        private readonly HotelBookingDbContext _context;

        public CreateEmployeeCommandHandler(HotelBookingDbContext context) => _context = context;

        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Domain.Entities.Employee
            {
                HotelId = request.HotelId,
                FullName = request.FullName,
                Role = request.Role,
                Email = request.Email
            };

            _context.Employees.Add(employee);
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}