using YashGems.Commerce.Domain.Entities;

namespace YashGems.Commerce.Domain.Repositories
{
    public interface IStoneQualityRepository
    {
        Task<IEnumerable<StoneQuality>> GetAllAsync();
        Task<StoneQuality?> GetByIdAsync(int id);
        Task AddAsync(StoneQuality quality);
        Task Update(StoneQuality quality);
        Task Delete(StoneQuality quality);
    }
}
