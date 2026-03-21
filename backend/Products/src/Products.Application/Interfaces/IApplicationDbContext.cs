using Microsoft.EntityFrameworkCore;
using Products.Domain.Entities;

namespace Products.Application.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<Product> Products { get; }
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}