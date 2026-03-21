namespace Products.Application.Dtos;

public class ProductDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; } = null!;
    public required string Description { get; set; } = null!;
    public required string Photo { get; set; } = null!;
    public required decimal Price { get; set; }
}