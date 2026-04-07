using YashGems.Commerce.Domain.Entities;
using YashGems.Commerce.Domain.Repositories;
using YashGems.Commerce.Infrastructure.Persistence;

namespace YashGems.Commerce.Infrastructure.Repositories
{
    public class GemstoneTypeRepository : RepositoryBase<GemstoneType>, IGemstoneTypeRepository
    {
        public GemstoneTypeRepository(DataContext context) : base(context) { }
    }
}
