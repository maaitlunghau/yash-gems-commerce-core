using YashGems.Commerce.Application.DTOs;

namespace YashGems.Commerce.Application.Interfaces
{
    public interface IGemstoneTypeService
    {
        Task<IEnumerable<GemstoneTypeDto>> GetAllAsync();
        Task<GemstoneTypeDto?> GetByIdAsync(int id);
        Task CreateAsync(GemstoneTypeDto dto);
        Task UpdateAsync(int id, GemstoneTypeDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
