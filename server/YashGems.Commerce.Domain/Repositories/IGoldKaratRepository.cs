using YashGems.Commerce.Domain.Entities;

namespace YashGems.Commerce.Domain.Repositories;

public interface IGoldKaratRepository
{
    Task<IEnumerable<GoldKarat>> GetAllAsync();
    Task<GoldKarat?> GetByIdAsync(int id);
    Task AddAsync(GoldKarat karat);
    Task Update(GoldKarat karat);
    Task Delete(GoldKarat karat);
}
