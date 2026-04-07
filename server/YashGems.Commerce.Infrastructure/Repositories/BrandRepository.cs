using YashGems.Commerce.Domain.Entities;
using YashGems.Commerce.Domain.Repositories;
using YashGems.Commerce.Infrastructure.Persistence;

namespace YashGems.Commerce.Infrastructure.Repositories;

public class BrandRepository : RepositoryBase<Brand>, IBrandRepository
{
    public BrandRepository(DataContext context) : base(context) { }
}
