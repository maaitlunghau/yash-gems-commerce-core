using YashGems.Commerce.Domain.Enums;

namespace YashGems.Commerce.Application.DTOs
{
    public class UpdateProductDto
    {
        public string? Name { get; set; }
        public string? StyleCode { get; set; }
        public string? Description { get; set; }
        public int? Quantity { get; set; }
        public ProductStatus? Status { get; set; }

        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public int? JewelTypeId { get; set; }
        public int? CertificationId { get; set; }

        public int? GoldKaratId { get; set; }
        public decimal? GoldWeight { get; set; }

        public int? DiamondPieces { get; set; }
        public decimal? DiamondWeight { get; set; }
        public int? DiamondColorId { get; set; }
        public int? DiamondClarityId { get; set; }
        public int? DiamondCutId { get; set; }

        public int? GemstonePieces { get; set; }
        public decimal? GemstoneWeight { get; set; }
        public int? GemstoneTypeId { get; set; }
        public int? StoneQualityId { get; set; }

        public decimal? GoldMakingCharge { get; set; }
        public decimal? StoneMakingCharge { get; set; }
        public decimal? OtherMakingCharge { get; set; }
        public decimal? Wastage { get; set; }
        public decimal? Tax { get; set; }
        public decimal? MRP { get; set; }
    }
}
