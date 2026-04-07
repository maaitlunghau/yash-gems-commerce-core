using YashGems.Commerce.Domain.Entities;

namespace YashGems.Commerce.Domain.Repositories;

public interface ICertificationRepository
{
    Task<IEnumerable<Certification>> GetAllAsync();
    Task<Certification?> GetByIdAsync(int id);
    Task AddAsync(Certification cert);
    Task Update(Certification cert);
    Task Delete(Certification cert);
}
