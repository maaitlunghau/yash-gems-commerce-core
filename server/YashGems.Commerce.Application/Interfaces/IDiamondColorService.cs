using YashGems.Commerce.Application.DTOs;

namespace YashGems.Commerce.Application.Interfaces
{
    public interface IDiamondColorService
    {
        Task<IEnumerable<DiamondColorDto>> GetAllAsync();
        Task<DiamondColorDto?> GetByIdAsync(int id);
        Task CreateAsync(DiamondColorDto dto);
        Task UpdateAsync(int id, DiamondColorDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
