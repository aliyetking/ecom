namespace ECom.Application.Interfaces;

public interface IUnitOfWork
{
    IProductRepository Products { get; }
    
    Task<int> SaveChangesAsync(CancellationToken ct = default);
    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
}