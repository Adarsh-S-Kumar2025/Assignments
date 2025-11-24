using HotelBookingSystem.DTOs.Booking;
using HotelBookingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _service;
        public BookingController(IBookingService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Add(BookingAddDto dto)
            => CreatedAtAction(nameof(Get), new { id = (await _service.AddAsync(dto)).Id }, dto);

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, BookingUpdateDto dto)
            => id != dto.Id ? BadRequest() : await _service.UpdateAsync(dto) is { } b ? Ok(b) : NotFound();

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
            => await _service.GetByIdAsync(id) is { } b ? Ok(b) : NotFound();

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