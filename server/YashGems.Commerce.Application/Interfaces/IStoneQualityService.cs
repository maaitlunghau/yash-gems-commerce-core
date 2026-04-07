using YashGems.Commerce.Application.DTOs;

namespace YashGems.Commerce.Application.Interfaces
{
    public interface IStoneQualityService
    {
        Task<IEnumerable<StoneQualityDto>> GetAllAsync();
        Task<StoneQualityDto?> GetByIdAsync(int id);
        Task CreateAsync(StoneQualityDto dto);
        Task UpdateAsync(int id, StoneQualityDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
