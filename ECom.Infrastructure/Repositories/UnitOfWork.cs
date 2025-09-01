using ECom.Application.Interfaces;
using ECom.Infrastructure.Persistences;
using Microsoft.EntityFrameworkCore.Storage;

namespace ECom.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ECommerceDbContext _context;
    
    private IDbContextTransaction _transaction;

    public UnitOfWork(ECommerceDbContext context, IProductRepository productRepository)
    {
        _context = context;
        Products = productRepository;
    }

    public IProductRepository Products { get; }

    public async Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        return await _context.SaveChangesAsync(ct);
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
        await _transaction.CommitAsync();
    }

    public async Task RollbackAsync()
    {
        await _transaction.RollbackAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}