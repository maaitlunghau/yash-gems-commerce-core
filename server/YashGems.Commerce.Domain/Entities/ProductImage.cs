using YashGems.Commerce.Domain.Common;

namespace YashGems.Commerce.Domain.Entities
{
    public class ProductImage : BaseEntity
    {
        public string Url { get; set; } = string.Empty;
        public string PublicId { get; set; } = string.Empty;
        public bool IsMain { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
