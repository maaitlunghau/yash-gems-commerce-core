namespace YashGems.Commerce.Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    Task<int> CompleteAsync();
}
