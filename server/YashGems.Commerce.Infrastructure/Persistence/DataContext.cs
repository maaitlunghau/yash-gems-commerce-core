using Microsoft.EntityFrameworkCore;

namespace YashGems.Commerce.Infrastructure.Persistence;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
}
