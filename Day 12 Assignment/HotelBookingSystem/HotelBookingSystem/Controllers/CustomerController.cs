using HotelBookingSystem.DTOs.Customer;
using HotelBookingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;
        public CustomerController(ICustomerService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Add(CustomerAddDto dto)
            => CreatedAtAction(nameof(Get), new { id = (await _service.AddAsync(dto)).Id }, dto);

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, CustomerUpdateDto dto)
            => id != dto.Id ? BadRequest() : await _service.UpdateAsync(dto) is { } c ? Ok(c) : NotFound();

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
            => await _service.GetByIdAsync(id) is { } c ? Ok(c) : NotFound();

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