using HotelBookingSystem.DTOs.Payment;
using HotelBookingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    [ApiController]
    [Route("api/payments")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _service;
        public PaymentController(IPaymentService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Add(PaymentAddDto dto)
            => CreatedAtAction(nameof(Get), new { id = (await _service.AddAsync(dto)).Id }, dto);

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, PaymentUpdateDto dto)
            => id != dto.Id ? BadRequest() : await _service.UpdateAsync(dto) is { } p ? Ok(p) : NotFound();

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
            => await _service.GetByIdAsync(id) is { } p ? Ok(p) : NotFound();

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