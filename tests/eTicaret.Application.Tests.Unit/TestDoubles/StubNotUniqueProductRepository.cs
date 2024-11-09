using eTicaret.Domain;

namespace eTicaret.Tests.Unit.TestDoubles;

public sealed class StubNotUniqueProductRepository : IProductRepository
{
    public async Task<bool> IsNameExists(string name, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return true;
    }

    public Task CreateAsync(Product product, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public void Delete(Product product)
    {
        throw new NotImplementedException();
    }
}
