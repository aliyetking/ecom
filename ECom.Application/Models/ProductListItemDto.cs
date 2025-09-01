using ECom.Domain.Entities;

namespace ECom.Application.Models;

public class ProductListItemDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public required int Stock { get; set; }
    public required CategoryDto Category { get; set; }
}