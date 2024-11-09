using eTicaret.Domain;
using eTicaret.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace eTicaret.Infrastructure.Repositories;
internal sealed class ProductRepository(
    ApplicationDbContext context) : IProductRepository
{
    public async Task CreateAsync(Product product, CancellationToken cancellationToken)
    {
        await context.Products.AddAsync(product, cancellationToken);
    }

    public void Delete(Product product)
    {
        context.Remove(product);
    }

    public async Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Products.FirstAsync(p => p.Id == id, cancellationToken);
    }

    public async Task<bool> IsNameExists(string name, CancellationToken cancellationToken)
    {
        return await context.Products.AnyAsync(p => p.Name == name, cancellationToken);
    }
}
