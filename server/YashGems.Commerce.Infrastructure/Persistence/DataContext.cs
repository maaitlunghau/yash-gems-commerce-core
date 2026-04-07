using Microsoft.EntityFrameworkCore;
using YashGems.Commerce.Domain.Entities;

namespace YashGems.Commerce.Infrastructure.Persistence;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<JewelType> JewelTypes { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<GoldKarat> GoldKarats { get; set; }
    public DbSet<Certification> Certifications { get; set; }
}
