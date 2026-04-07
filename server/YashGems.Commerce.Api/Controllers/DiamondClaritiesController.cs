using Microsoft.AspNetCore.Mvc;
using YashGems.Commerce.Application.DTOs;
using YashGems.Commerce.Application.Interfaces;

namespace YashGems.Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiamondClaritiesController : ControllerBase
    {
        private readonly IDiamondClarityService _service;

        public DiamondClaritiesController(IDiamondClarityService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiamondClarityDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DiamondClarityDto>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(DiamondClarityDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok(new { message = "Diamond Clarity created successfully" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, DiamondClarityDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return Ok(new { message = "Diamond Clarity updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result) return NotFound();
            return Ok(new { message = "Diamond Clarity deleted successfully" });
        }
    }
}
