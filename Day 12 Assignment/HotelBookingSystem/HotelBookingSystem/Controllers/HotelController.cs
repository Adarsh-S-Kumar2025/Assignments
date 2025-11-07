using HotelBookingSystem.DTOs.Hotel;
using HotelBookingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

[ApiController]
[Route("api/hotels")]
public class HotelController : ControllerBase
{
    private readonly IHotelService _svc;
    public HotelController(IHotelService svc) => _svc = svc;

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] HotelAddDto dto)
        => Ok(await _svc.AddAsync(dto));

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] HotelUpdateDto dto)
        => await _svc.UpdateAsync(dto) is { } h ? Ok(h) : NotFound();

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
        => await _svc.GetByIdAsync(id) is { } h ? Ok(h) : NotFound();

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _svc.DeleteAsync(id);
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> List()
        => Ok(await _svc.ListAsync());
}