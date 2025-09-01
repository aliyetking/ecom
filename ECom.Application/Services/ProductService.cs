using ECom.Application.Interfaces;
using ECom.Application.Mapper;
using ECom.Application.Models;

namespace ECom.Application.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ProductMapper _productMapper;

    public ProductService(IUnitOfWork unitOfWork, ProductMapper productMapper)
    {
        _unitOfWork = unitOfWork;
        _productMapper = productMapper;
    }
    
    public async Task CreateProduct(CreateProductDto productDto, CancellationToken ct)
    {
        var product = _productMapper.FromCreateDto(productDto);
        
        await _unitOfWork.Products.AddAsync(product, ct);
        await _unitOfWork.SaveChangesAsync(ct);;
    }

    public async Task<List<ProductListItemDto>> ListAllProducts(CancellationToken ct)
    {
        var products = await _unitOfWork.Products.GetAllWithCategoryAsync(ct);
        return products.Select(product => _productMapper.ToListItemDto(product)).ToList();
    }
}