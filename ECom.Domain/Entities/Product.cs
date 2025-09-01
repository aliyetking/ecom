namespace ECom.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public required int Stock { get; set; }

    public required int CategoryId { get; set; }
    public Category Category { get; set; }
}