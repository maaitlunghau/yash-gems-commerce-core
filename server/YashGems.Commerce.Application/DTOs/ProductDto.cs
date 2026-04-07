namespace YashGems.Commerce.Application.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string StyleCode { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; } = string.Empty;

        // Catalog Names
        public string? CategoryName { get; set; }
        public string? BrandName { get; set; }
        public string? JewelTypeName { get; set; }
        public string? CertificationName { get; set; }

        public string? GoldKaratName { get; set; }
        public decimal? GoldWeight { get; set; }

        // Diamond Info
        public int? DiamondPieces { get; set; }
        public decimal? DiamondWeight { get; set; }
        public string? DiamondColorName { get; set; }
        public string? DiamondClarityName { get; set; }
        public string? DiamondCutName { get; set; }

        // Gemstone Info
        public int? GemstonePieces { get; set; }
        public decimal? GemstoneWeight { get; set; }
        public string? GemstoneTypeName { get; set; }
        public string? StoneQualityName { get; set; }

        // Pricing Info
        public decimal GoldMakingCharge { get; set; }
        public decimal StoneMakingCharge { get; set; }
        public decimal OtherMakingCharge { get; set; }
        public decimal Wastage { get; set; }
        public decimal Tax { get; set; }
        public decimal MRP { get; set; }

        public ICollection<ProductImageDto>? Images { get; set; }
    }
}
