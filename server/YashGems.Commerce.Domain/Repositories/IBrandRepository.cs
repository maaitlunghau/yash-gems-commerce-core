using YashGems.Commerce.Domain.Entities;

namespace YashGems.Commerce.Domain.Repositories;

public interface IBrandRepository
{
    Task<IEnumerable<Brand>> GetAllAsync();
    Task<Brand?> GetByIdAsync(int id);
    Task AddAsync(Brand brand);
    Task Update(Brand brand);
    Task Delete(Brand brand);
}
