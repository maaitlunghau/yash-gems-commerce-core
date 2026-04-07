using YashGems.Commerce.Domain.Common;
using YashGems.Commerce.Domain.Enums;

namespace YashGems.Commerce.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string StyleCode { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public ProductStatus Status { get; set; } = ProductStatus.Active;

        // Catalog Info
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public int? BrandId { get; set; }
        public Brand? Brand { get; set; }

        public int? JewelTypeId { get; set; }
        public JewelType? JewelType { get; set; }

        public int? CertificationId { get; set; }
        public Certification? Certification { get; set; }

        // Gold Info
        public int? GoldKaratId { get; set; }
        public GoldKarat? GoldKarat { get; set; }
        public decimal? GoldWeight { get; set; }

        // Diamond Info
        public int? DiamondPieces { get; set; }
        public decimal? DiamondWeight { get; set; } // Carat

        public int? DiamondColorId { get; set; }
        public DiamondColor? DiamondColor { get; set; }

        public int? DiamondClarityId { get; set; }
        public DiamondClarity? DiamondClarity { get; set; }

        public int? DiamondCutId { get; set; }
        public DiamondCut? DiamondCut { get; set; }

        // Gemstone Info
        public int? GemstonePieces { get; set; }
        public decimal? GemstoneWeight { get; set; }

        public int? GemstoneTypeId { get; set; }
        public GemstoneType? GemstoneType { get; set; }

        public int? StoneQualityId { get; set; }
        public StoneQuality? StoneQuality { get; set; }

        // Pricing Info
        public decimal GoldMakingCharge { get; set; }
        public decimal StoneMakingCharge { get; set; }
        public decimal OtherMakingCharge { get; set; }
        public decimal Wastage { get; set; } // tỉ lệ hao hụt (%)
        public decimal Tax { get; set; }
        public decimal MRP { get; set; } // tính toán tự động
    }
}
