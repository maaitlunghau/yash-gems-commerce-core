using YashGems.Commerce.Application.DTOs;

namespace YashGems.Commerce.Application.Interfaces;

public interface IBrandService
{
    Task<IEnumerable<BrandDto>> GetAllAsync();
    Task<BrandDto?> GetByIdAsync(int id);
    Task CreateAsync(BrandDto dto);
    Task UpdateAsync(int id, BrandDto dto);
    Task<bool> DeleteAsync(int id);
}
