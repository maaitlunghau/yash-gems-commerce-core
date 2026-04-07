using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YashGems.Commerce.Application.DTOs;
using YashGems.Commerce.Application.Interfaces;

namespace YashGems.Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JewelTypesController : ControllerBase
    {
        private readonly IJewelTypeService _service;
        public JewelTypesController(IJewelTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JewelTypeDto>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JewelTypeDto>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(JewelTypeDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok(new { message = "Jewel type created successfully" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, JewelTypeDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return Ok(new { message = "Jewel type updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound(new { message = $"Jewel type with ID {id} not found" });

            return Ok(new { message = "Jewel type deleted successfully" });
        }
    }
}
