using YashGems.Commerce.Domain.Entities;
using YashGems.Commerce.Domain.Repositories;
using YashGems.Commerce.Infrastructure.Persistence;

namespace YashGems.Commerce.Infrastructure.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(DataContext context) : base(context) { }
    }
}
