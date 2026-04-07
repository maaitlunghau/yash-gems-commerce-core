using YashGems.Commerce.Domain.Entities;

namespace YashGems.Commerce.Domain.Repositories
{
    public interface IDiamondColorRepository
    {
        Task<IEnumerable<DiamondColor>> GetAllAsync();
        Task<DiamondColor?> GetByIdAsync(int id);
        Task AddAsync(DiamondColor color);
        Task Update(DiamondColor color);
        Task Delete(DiamondColor color);
    }
}
