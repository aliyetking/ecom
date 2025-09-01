using ECom.Application.Interfaces;
using ECom.Domain.Entities;
using ECom.Infrastructure.Persistences;
using Microsoft.EntityFrameworkCore;

namespace ECom.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ECommerceDbContext _dbContext;

    public ProductRepository(ECommerceDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<Product>> GetAllWithCategoryAsync(CancellationToken ct = default)
    {
        return await _dbContext.Products.Include(a => a.Category).ToListAsync(ct);
    }

    public async Task AddAsync(Product product, CancellationToken ct = default)
    {
        await _dbContext.Products.AddAsync(product, ct);
    }
}