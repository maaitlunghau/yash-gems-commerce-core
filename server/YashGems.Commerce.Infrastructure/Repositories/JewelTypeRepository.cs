using YashGems.Commerce.Domain.Entities;
using YashGems.Commerce.Domain.Repositories;
using YashGems.Commerce.Infrastructure.Persistence;

namespace YashGems.Commerce.Infrastructure.Repositories;

public class JewelTypeRepository : RepositoryBase<JewelType>, IJewelTypeRepository
{
    public JewelTypeRepository(DataContext context) : base(context) { }
}
