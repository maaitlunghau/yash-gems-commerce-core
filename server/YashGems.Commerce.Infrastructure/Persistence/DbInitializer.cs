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
    }
}
