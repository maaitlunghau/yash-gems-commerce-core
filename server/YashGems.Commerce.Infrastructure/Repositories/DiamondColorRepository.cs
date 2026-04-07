using YashGems.Commerce.Domain.Entities;
using YashGems.Commerce.Domain.Repositories;
using YashGems.Commerce.Infrastructure.Persistence;

namespace YashGems.Commerce.Infrastructure.Repositories
{
    public class DiamondColorRepository : RepositoryBase<DiamondColor>, IDiamondColorRepository
    {
        public DiamondColorRepository(DataContext context) : base(context) { }
    }
}
