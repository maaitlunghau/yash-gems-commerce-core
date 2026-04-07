using Microsoft.AspNetCore.Mvc;
using YashGems.Commerce.Application.DTOs;
using YashGems.Commerce.Application.Interfaces;

namespace YashGems.Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoldKaratsController : ControllerBase
    {
        private readonly IGoldKaratService _service;
        public GoldKaratsController(IGoldKaratService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GoldKaratDto>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GoldKaratDto>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(GoldKaratDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok(new { message = "Gold karat created successfully" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, GoldKaratDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return Ok(new { message = "Gold karat updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok(new { message = "Gold karat deleted successfully" });
        }
    }
}
