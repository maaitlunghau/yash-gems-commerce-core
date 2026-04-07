using YashGems.Commerce.Domain.Common;

namespace YashGems.Commerce.Domain.Entities
{
    public class GemstoneType : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
