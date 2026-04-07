using YashGems.Commerce.Domain.Entities;
using YashGems.Commerce.Domain.Repositories;
using YashGems.Commerce.Infrastructure.Persistence;

namespace YashGems.Commerce.Infrastructure.Repositories
{
    public class DiamondCutRepository : RepositoryBase<DiamondCut>, IDiamondCutRepository
    {
        public DiamondCutRepository(DataContext context) : base(context) { }
    }
}
