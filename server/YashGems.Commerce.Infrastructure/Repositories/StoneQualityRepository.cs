using YashGems.Commerce.Domain.Entities;
using YashGems.Commerce.Domain.Repositories;
using YashGems.Commerce.Infrastructure.Persistence;

namespace YashGems.Commerce.Infrastructure.Repositories
{
    public class StoneQualityRepository : RepositoryBase<StoneQuality>, IStoneQualityRepository
    {
        public StoneQualityRepository(DataContext context) : base(context) { }
    }
}
