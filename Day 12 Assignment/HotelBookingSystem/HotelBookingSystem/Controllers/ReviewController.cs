using HotelBookingSystem.DTOs.Review;
using HotelBookingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    [ApiController]
    [Route("api/reviews")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _service;
        public ReviewController(IReviewService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Add(ReviewAddDto dto)
            => CreatedAtAction(nameof(Get), new { id = (await _service.AddAsync(dto)).Id }, dto);

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, ReviewUpdateDto dto)
            => id != dto.Id ? BadRequest() : await _service.UpdateAsync(dto) is { } r ? Ok(r) : NotFound();

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
            => await _service.GetByIdAsync(id) is { } r ? Ok(r) : NotFound();

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