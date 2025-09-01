namespace ECom.Application.Models;

public class CreateProductDto
{
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public required int Stock { get; set; }

    public required int CategoryId { get; set; }
}