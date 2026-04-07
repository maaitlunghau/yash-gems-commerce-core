using YashGems.Commerce.Domain.Entities;

namespace YashGems.Commerce.Domain.Repositories
{
    public interface IDiamondClarityRepository
    {
        Task<IEnumerable<DiamondClarity>> GetAllAsync();
        Task<DiamondClarity?> GetByIdAsync(int id);
        Task AddAsync(DiamondClarity clarity);
        Task Update(DiamondClarity clarity);
        Task Delete(DiamondClarity clarity);
    }
}
