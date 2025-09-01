namespace ECom.Domain.Entities;

public class Category
{
    public required int Id { get; set; }
    public required string Name { get; set; }

    public List<Product> Products { get; set; }
}