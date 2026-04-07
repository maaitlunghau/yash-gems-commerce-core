using YashGems.Commerce.Application.DTOs;

namespace YashGems.Commerce.Application.Interfaces;

public interface ICertificationService
{
    Task<IEnumerable<CertificationDto>> GetAllAsync();
    Task<CertificationDto?> GetByIdAsync(int id);
    Task CreateAsync(CertificationDto dto);
    Task UpdateAsync(int id, CertificationDto dto);
    Task<bool> DeleteAsync(int id);
}
