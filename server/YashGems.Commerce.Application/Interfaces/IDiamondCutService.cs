using YashGems.Commerce.Application.DTOs;

namespace YashGems.Commerce.Application.Interfaces
{
    public interface IDiamondCutService
    {
        Task<IEnumerable<DiamondCutDto>> GetAllAsync();
        Task<DiamondCutDto?> GetByIdAsync(int id);
        Task CreateAsync(DiamondCutDto dto);
        Task UpdateAsync(int id, DiamondCutDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
