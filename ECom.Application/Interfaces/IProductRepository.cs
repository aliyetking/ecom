using ECom.Domain.Entities;

namespace ECom.Application.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetAllWithCategoryAsync(CancellationToken ct = default);
    Task AddAsync(Product product, CancellationToken ct = default);
}