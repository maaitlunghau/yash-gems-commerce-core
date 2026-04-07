using YashGems.Commerce.Application.DTOs;

namespace YashGems.Commerce.Application.Interfaces
{
    public interface IDiamondClarityService
    {
        Task<IEnumerable<DiamondClarityDto>> GetAllAsync();
        Task<DiamondClarityDto?> GetByIdAsync(int id);
        Task CreateAsync(DiamondClarityDto dto);
        Task UpdateAsync(int id, DiamondClarityDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
