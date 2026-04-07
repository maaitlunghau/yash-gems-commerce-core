using YashGems.Commerce.Domain.Entities;
using YashGems.Commerce.Domain.Repositories;
using YashGems.Commerce.Infrastructure.Persistence;

namespace YashGems.Commerce.Infrastructure.Repositories
{
    public class DiamondClarityRepository : RepositoryBase<DiamondClarity>, IDiamondClarityRepository
    {
        public DiamondClarityRepository(DataContext context) : base(context) { }
    }
}
