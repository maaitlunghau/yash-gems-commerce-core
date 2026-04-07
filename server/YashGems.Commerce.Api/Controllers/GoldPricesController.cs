using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YashGems.Commerce.Infrastructure.Persistence;

namespace YashGems.Commerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoldPricesController : ControllerBase
    {
        private readonly DataContext _context;

        public GoldPricesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("latest")]
        public async Task<IActionResult> GetLatest()
        {
            var latest = await _context.GoldPriceHistories
                .OrderByDescending(x => x.UpdatedAt)
                .FirstOrDefaultAsync();

            if (latest == null) return NotFound("No gold price history found.");

            return Ok(latest);
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetHistory([FromQuery] int limit = 30)
        {
            var history = await _context.GoldPriceHistories
                .OrderByDescending(x => x.UpdatedAt)
                .Take(limit)
                .OrderBy(x => x.UpdatedAt)
                .ToListAsync();

            return Ok(history);
        }
    }
}
