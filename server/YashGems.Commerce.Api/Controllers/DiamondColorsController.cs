using Microsoft.AspNetCore.Mvc;
using YashGems.Commerce.Application.DTOs;
using YashGems.Commerce.Application.Interfaces;

namespace YashGems.Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiamondColorsController : ControllerBase
    {
        private readonly IDiamondColorService _service;

        public DiamondColorsController(IDiamondColorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiamondColorDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DiamondColorDto>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(DiamondColorDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok(new { message = "Diamond Color created successfully" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, DiamondColorDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return Ok(new { message = "Diamond Color updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result) return NotFound();
            return Ok(new { message = "Diamond Color deleted successfully" });
        }
    }
}
