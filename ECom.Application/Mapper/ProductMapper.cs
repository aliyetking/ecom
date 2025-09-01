using ECom.Application.Models;
using ECom.Domain.Entities;

namespace ECom.Application.Mapper;

public class ProductMapper
{
    public Product FromCreateDto(CreateProductDto dto)
    {
        return new Product()
        {
            Name = dto.Name,
            CategoryId = dto.CategoryId,
            Price = dto.Price,
            Stock = dto.Stock
        };
    }

    public ProductListItemDto ToListItemDto(Product product)
    {
        return new ProductListItemDto()
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            Category = new CategoryDto
            {
                Id = product.CategoryId,
                Name = product.Category.Name
            }
        };
    }
}