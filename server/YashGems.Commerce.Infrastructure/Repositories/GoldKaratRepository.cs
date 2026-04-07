using YashGems.Commerce.Domain.Entities;
using YashGems.Commerce.Domain.Repositories;
using YashGems.Commerce.Infrastructure.Persistence;

namespace YashGems.Commerce.Infrastructure.Repositories;

public class GoldKaratRepository : RepositoryBase<GoldKarat>, IGoldKaratRepository
{
    public GoldKaratRepository(DataContext context) : base(context) { }
}
