using YashGems.Commerce.Domain.Entities;

namespace YashGems.Commerce.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product?> GetByStyleCodeAsync(string styleCode);
        Task AddAsync(Product product);
        Task Update(Product product);
        Task Delete(Product product);
    }
}
