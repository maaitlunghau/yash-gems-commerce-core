using YashGems.Commerce.Domain.Entities;

namespace YashGems.Commerce.Domain.Repositories
{
    public interface IDiamondCutRepository
    {
        Task<IEnumerable<DiamondCut>> GetAllAsync();
        Task<DiamondCut?> GetByIdAsync(int id);
        Task AddAsync(DiamondCut cut);
        Task Update(DiamondCut cut);
        Task Delete(DiamondCut cut);
    }
}
