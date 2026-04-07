using YashGems.Commerce.Application.DTOs;

namespace YashGems.Commerce.Application.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllAsync();
    Task<CategoryDto?> GetByIdAsync(int id);
    Task CreateAsync(CategoryDto dto);
    Task UpdateAsync(int id, CategoryDto dto);
    Task DeleteAsync(int id);
}
