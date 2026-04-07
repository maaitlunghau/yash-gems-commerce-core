using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YashGems.Commerce.Infrastructure.Persistence;
using YashGems.Commerce.Application.Interfaces;
using YashGems.Commerce.Domain.Entities;

namespace YashGems.Commerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoldPricesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IGoldPriceService _goldPriceService;

        public GoldPricesController(DataContext context, IGoldPriceService goldPriceService)
        {
            _context = context;
            _goldPriceService = goldPriceService;
        }

        // Lấy Tỉ giá USD -> VND hiện tại
        [HttpGet("exchange-rate")]
        public async Task<IActionResult> GetExchangeRate()
        {
            var rate = await _goldPriceService.GetLatestExchangeRateAsync();
            return Ok(new { Currency = "VND", Base = "USD", Rate = rate });
        }

        // Ép cập nhật giá vàng từ API ngay bây giờ
        [HttpPost("fetch-latest")]
        public async Task<IActionResult> ManualFetchAndSave()
        {
            try 
            {
                var currentPriceVnd = await _goldPriceService.GetLatestGoldPriceInVndAsync();
                
                var history = new GoldPriceHistory 
                { 
                    PricePerGram = currentPriceVnd,
                    Source = "Manual Trigger"
                };

                _context.GoldPriceHistories.Add(history);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "Succeeded!", Data = history });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
