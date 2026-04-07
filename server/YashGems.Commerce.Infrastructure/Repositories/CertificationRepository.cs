using YashGems.Commerce.Domain.Entities;
using YashGems.Commerce.Domain.Repositories;
using YashGems.Commerce.Infrastructure.Persistence;

namespace YashGems.Commerce.Infrastructure.Repositories;

public class CertificationRepository : RepositoryBase<Certification>, ICertificationRepository
{
    public CertificationRepository(DataContext context) : base(context) { }
}