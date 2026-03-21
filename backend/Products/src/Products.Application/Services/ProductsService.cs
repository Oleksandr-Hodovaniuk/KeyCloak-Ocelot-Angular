using Microsoft.EntityFrameworkCore;
using Products.Application.Dtos;
using Products.Application.Interfaces;
using Products.Domain.Entities;

namespace Products.Application.Services;

public class ProductsService(IApplicationDbContext _context) : IProductsService
{
    public async Task CreateAsync(CreateProductDto dto, CancellationToken ct = default)
    {
        var product = new Product 
        {
            Name = dto.Name,
            Description = dto.Description,
            Photo = dto.Photo,
            Price = dto.Price
        };

        await _context.Products.AddAsync(product, ct);
        await _context.SaveChangesAsync(ct);  
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync(CancellationToken ct = default)
    {
        var products = await _context.Products.ToListAsync(ct);

        var productsDtos = new List<ProductDto>();

        foreach (var product in products)
        {
            productsDtos.Add(new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Photo = product.Photo,
                Price = product.Price
            });
        }

        return productsDtos;
    }

    public async Task<ProductDto> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id, ct);

        if (product == null)
            throw new Exception($"Product with id: {id} doesn't exist");

        var productDto = new ProductDto
        {
            Id = product.Id,
            Name= product.Name,
            Description= product.Description,
            Photo= product.Photo,
            Price= product.Price
        };

        return productDto;
    }

    public async Task RemoveAsync(Guid id, CancellationToken ct = default)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

        if (product == null)
            throw new Exception($"Product with id: {id} doesn't exist");

        _context.Products.Remove(product);
        await _context.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(UpdateProductDto dto, CancellationToken ct = default)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == dto.Id, ct);

        if (product == null)
            throw new Exception($"Product with id: {dto.Id} doesn't exist");

        product.Name = dto.Name ?? product.Name;
        product.Description = dto.Description ?? product.Description;
        product.Photo = dto.Photo ?? product.Photo;
        product.Price = dto.Price ?? product.Price;

        _context.Products.Update(product);
        await _context.SaveChangesAsync(ct);
    }
}
