using YashGems.Commerce.Domain.Entities;

namespace YashGems.Commerce.Domain.Repositories
{
    public interface IGemstoneTypeRepository
    {
        Task<IEnumerable<GemstoneType>> GetAllAsync();
        Task<GemstoneType?> GetByIdAsync(int id);
        Task AddAsync(GemstoneType type);
        Task Update(GemstoneType type);
        Task Delete(GemstoneType type);
    }
}
