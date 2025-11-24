using HotelBookingSystem.DTOs.Employee;
using HotelBookingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        public EmployeeController(IEmployeeService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeAddDto dto)
            => CreatedAtAction(nameof(Get), new { id = (await _service.AddAsync(dto)).Id }, dto);

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, EmployeeUpdateDto dto)
            => id != dto.Id ? BadRequest() : await _service.UpdateAsync(dto) is { } e ? Ok(e) : NotFound();

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
            => await _service.GetByIdAsync(id) is { } e ? Ok(e) : NotFound();

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> List()
            => Ok(await _service.ListAsync());
    }
}