using Products.Application.Dtos;
using Products.Domain.Entities;

namespace Products.Application.Interfaces;

public interface IProductsService
{
    public Task<IEnumerable<ProductDto>> GetAllAsync(CancellationToken ct = default);
    public Task<ProductDto> GetByIdAsync(Guid id, CancellationToken ct = default);
    public Task CreateAsync(CreateProductDto dto, CancellationToken ct = default);
    public Task UpdateAsync(UpdateProductDto dto, CancellationToken ct = default);
    public Task RemoveAsync(Guid id, CancellationToken ct = default);
}