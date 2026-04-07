using Microsoft.EntityFrameworkCore;
using YashGems.Commerce.Domain.Entities;

namespace YashGems.Commerce.Infrastructure.Persistence;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<JewelType> JewelTypes { get; set; } = null!;
    public DbSet<Brand> Brands { get; set; } = null!;
    public DbSet<GoldKarat> GoldKarats { get; set; } = null!;
    public DbSet<Certification> Certifications { get; set; } = null!;
    public DbSet<DiamondColor> DiamondColors { get; set; } = null!;
    public DbSet<DiamondClarity> DiamondClarities { get; set; } = null!;
    public DbSet<DiamondCut> DiamondCuts { get; set; } = null!;
    public DbSet<GemstoneType> GemstoneTypes { get; set; } = null!;
    public DbSet<StoneQuality> StoneQualities { get; set; } = null!;
}
