using ECom.Application.Models;

namespace ECom.Application.Interfaces;

public interface IProductService
{
    Task CreateProduct(CreateProductDto productDto, CancellationToken ct);
    Task<List<ProductListItemDto>> ListAllProducts(CancellationToken ct);
}