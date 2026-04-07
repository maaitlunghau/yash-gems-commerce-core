using YashGems.Commerce.Domain.Common;

namespace YashGems.Commerce.Domain.Entities
{
    public class GoldPriceHistory : BaseEntity
    {
        public decimal PricePerGram { get; set; }
        public string Source { get; set; } = "GoldAPI.io";
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
