using YashGems.Commerce.Domain.Entities;

namespace YashGems.Commerce.Infrastructure.Persistence;

public class DbInitializer
{
    public static async Task SeedAsync(DataContext context)
    {
        if (context.Categories.Any()) return;

        var categories = new List<Category>
            {
                new Category {
                    Name = "Nhẫn (Rings)",
                    Description = "Nhẫn đính hôn, nhẫn cưới..."
                },
                new Category {
                    Name = "Dây chuyền (Necklaces)",
                    Description = "Dây chuyền vàng, kim cương..."
                    },
                new Category {
                    Name = "Hoa tai (Earrings)",
                    Description = "Hoa tai đính đá quý..." }
            };
        await context.Categories.AddRangeAsync(categories);


        var jewelTypes = new List<JewelType>
            {
                new JewelType {
                    Name = "Trang sức dự tiệc (Fine Jewelry)",
                    Description = "Vàng tây cao cấp"
                    },
                new JewelType {
                    Name = "Trang sức thường ngày (Everyday Jewelry)",
                    Description = "Sang trọng và bền bỉ"
                    }
            };
        await context.JewelTypes.AddRangeAsync(jewelTypes);

        var brands = new List<Brand>
            {
                new Brand {
                    Name = "Yash Gems",
                    Description = "Thương hiệu nội bộ"
                },
                new Brand {
                    Name = "Tiffany & Co.",
                    Description = "Thương hiệu quốc tế"
                }
            };
        await context.Brands.AddRangeAsync(brands);


        var goldKarats = new List<GoldKarat>
            {
                new GoldKarat {
                    Name = "14K",
                    Karat = 14,
                    Description = "0.585m"
                    },
                new GoldKarat {
                    Name = "18K",
                    Karat = 18,
                    Description = "0.750m"
                },
                new GoldKarat {
                    Name = "24K",
                    Karat = 24,
                    Description = "0.999m"
                }
            };
        await context.GoldKarats.AddRangeAsync(goldKarats);

        var certifications = new List<Certification>
            {
                new Certification {
                    Name = "GIA",
                    IsActive = true
                },
                new Certification {
                    Name = "IGI",
                    IsActive = true
                }
            };
        await context.Certifications.AddRangeAsync(certifications);

        var diamondColors = new List<DiamondColor>
        {
            new DiamondColor { Name = "D", Description = "Colorless" },
            new DiamondColor { Name = "E", Description = "Colorless" },
            new DiamondColor { Name = "F", Description = "Colorless" },
            new DiamondColor { Name = "G", Description = "Near Colorless" }
        };
        await context.DiamondColors.AddRangeAsync(diamondColors);

        var diamondClarities = new List<DiamondClarity>
        {
            new DiamondClarity { Name = "FL", Description = "Flawless" },
            new DiamondClarity { Name = "IF", Description = "Internally Flawless" },
            new DiamondClarity { Name = "VVS1", Description = "Very Very Slightly Included 1" },
            new DiamondClarity { Name = "VVS2", Description = "Very Very Slightly Included 2" }
        };
        await context.DiamondClarities.AddRangeAsync(diamondClarities);

        var diamondCuts = new List<DiamondCut>
        {
            new DiamondCut { Name = "Ideal" },
            new DiamondCut { Name = "Excellent" },
            new DiamondCut { Name = "Very Good" },
            new DiamondCut { Name = "Good" }
        };
        await context.DiamondCuts.AddRangeAsync(diamondCuts);

        if (!context.GemstoneTypes.Any())
        {
            var gemstoneTypes = new List<GemstoneType>
            {
                new GemstoneType { Name = "Ruby", Description = "Hồng ngọc" },
                new GemstoneType { Name = "Sapphire", Description = "Lam ngọc" },
                new GemstoneType { Name = "Emerald", Description = "Ngọc lục bảo" },
                new GemstoneType { Name = "Aquamarine" },
                new GemstoneType { Name = "Amethyst" }
            };
            await context.GemstoneTypes.AddRangeAsync(gemstoneTypes);
        }

        if (!context.StoneQualities.Any())
        {
            var stoneQualities = new List<StoneQuality>
            {
                new StoneQuality { Name = "AAA", Description = "Cao cấp nhất, màu sắc rực rỡ, độ trong tuyệt đối" },
                new StoneQuality { Name = "AA", Description = "Chất lượng cao, rất ít tạp chất" },
                new StoneQuality { Name = "A", Description = "Chất lượng tốt, màu sắc tự nhiên" }
            };
            await context.StoneQualities.AddRangeAsync(stoneQualities);
        }

        await context.SaveChangesAsync();
    }
}
