namespace YashGems.Commerce.Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    Task<int> CompleteAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}
