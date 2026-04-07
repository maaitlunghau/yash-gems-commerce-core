using YashGems.Commerce.Application.DTOs;

namespace YashGems.Commerce.Application.Interfaces;

public interface IJewelTypeService
{
    Task<IEnumerable<JewelTypeDto>> GetAllAsync();
    Task<JewelTypeDto?> GetByIdAsync(int id);
    Task CreateAsync(JewelTypeDto dto);
    Task UpdateAsync(int id, JewelTypeDto dto);
    Task<bool> DeleteAsync(int id);
}
