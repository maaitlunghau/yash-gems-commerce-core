using YashGems.Commerce.Application.DTOs;

namespace YashGems.Commerce.Application.Interfaces;

public interface IGoldKaratService
{
    Task<IEnumerable<GoldKaratDto>> GetAllAsync();
    Task<GoldKaratDto?> GetByIdAsync(int id);
    Task CreateAsync(GoldKaratDto dto);
    Task UpdateAsync(int id, GoldKaratDto dto);
    Task DeleteAsync(int id);
}
