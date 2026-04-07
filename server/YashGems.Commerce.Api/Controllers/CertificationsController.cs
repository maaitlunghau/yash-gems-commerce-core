using Microsoft.AspNetCore.Mvc;
using YashGems.Commerce.Application.DTOs;
using YashGems.Commerce.Application.Interfaces;

namespace YashGems.Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificationsController : ControllerBase
    {
        private readonly ICertificationService _service;
        public CertificationsController(ICertificationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CertificationDto>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CertificationDto>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CertificationDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok(new { message = "Certification created successfully" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, CertificationDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return Ok(new { message = "Certification updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound(new { message = $"Certification with ID {id} not found" });

            return Ok(new { message = "Certification deleted successfully" });
        }
    }
}
