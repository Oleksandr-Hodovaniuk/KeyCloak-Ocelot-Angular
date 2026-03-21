namespace Products.Application.Dtos;

public class UpdateProductDto
{
    public Guid Id { get; set; }
    public  string? Name { get; set; } = null!;
    public  string? Description { get; set; } = null!;
    public  string? Photo { get; set; } = null!;
    public  decimal? Price { get; set; }
}
