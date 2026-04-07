using YashGems.Commerce.Domain.Entities;

namespace YashGems.Commerce.Domain.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(int id);
    Task AddAsync(Category cate);
    Task Update(Category cate);
    Task Delete(Category cate);
}