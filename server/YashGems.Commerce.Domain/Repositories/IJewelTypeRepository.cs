using YashGems.Commerce.Domain.Entities;

namespace YashGems.Commerce.Domain.Repositories;

public interface IJewelTypeRepository
{
    Task<IEnumerable<JewelType>> GetAllAsync();
    Task<JewelType?> GetByIdAsync(int id);
    Task AddAsync(JewelType type);
    Task Update(JewelType type);
    Task Delete(JewelType type);
}
