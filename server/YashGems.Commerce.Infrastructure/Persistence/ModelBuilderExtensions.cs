using Microsoft.EntityFrameworkCore;
using YashGems.Commerce.Domain.Entities;
using YashGems.Commerce.Domain.Enums;

namespace YashGems.Commerce.Infrastructure.Persistence
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Name = "Nhẫn Cưới", Description = "Nhẫn đính hôn và nhẫn cưới", IsActive = true });
            modelBuilder.Entity<Brand>().HasData(new Brand { Id = 1, Name = "YashGems Premium", Description = "Thương hiệu cao cấp nội bộ" });
            modelBuilder.Entity<JewelType>().HasData(new JewelType { Id = 1, Name = "Nhẫn Kép", Description = "Nhẫn cưới đôi" });
            modelBuilder.Entity<GoldKarat>().HasData(new GoldKarat { Id = 1, Name = "18K", Description = "Vàng 75%" });
            modelBuilder.Entity<DiamondColor>().HasData(new DiamondColor { Id = 1, Name = "D", Description = "Colorless" });
            modelBuilder.Entity<DiamondClarity>().HasData(new DiamondClarity { Id = 1, Name = "VVS1", Description = "Very Very Slightly Included" });
            modelBuilder.Entity<DiamondCut>().HasData(new DiamondCut { Id = 1, Name = "Excellent", Description = "Cắt xẻ hoàn mỹ" });
            modelBuilder.Entity<Certification>().HasData(new Certification { Id = 1, Name = "GIA Standard", Description = "Viện Đá Quý Hoa Kỳ" });
            modelBuilder.Entity<GemstoneType>().HasData(new GemstoneType { Id = 1, Name = "Ruby", Description = "Hồng Ngọc" });
            modelBuilder.Entity<StoneQuality>().HasData(new StoneQuality { Id = 1, Name = "AAA", Description = "Cao cấp" });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                StyleCode = "YG-RING-001",
                Name = "Nhẫn Kim Cương VVS1 Cổ Điển",
                Description = "Sự kết hợp hoàn hảo giữa Vàng 18K và Kim Cương nước D chuẩn GIA.",
                Quantity = 10,
                GoldWeight = 4.0m, // 4 grams
                DiamondWeight = 0.5m, 
                DiamondPieces = 1,
                CategoryId = 1,
                BrandId = 1,
                JewelTypeId = 1,
                GoldKaratId = 1,
                DiamondColorId = 1,
                DiamondClarityId = 1,
                DiamondCutId = 1,
                CertificationId = 1,
                GoldMakingCharge = 100m,
                StoneMakingCharge = 50m,
                OtherMakingCharge = 20m,
                Wastage = 5m, // 5% hao hụt
                Tax = 10m, // 10% thuế VAT
                MRP = 510.4m, // Mock giá MRP
                Status = ProductStatus.Active
            });
        }
    }
}
