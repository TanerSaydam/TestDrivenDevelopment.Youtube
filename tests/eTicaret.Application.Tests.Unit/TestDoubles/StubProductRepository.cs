using eTicaret.Domain;

namespace eTicaret.Tests.Unit.TestDoubles;

public sealed class StubProductRepository : IProductRepository
{

    public Task CreateAsync(Product product, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public void Delete(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> IsNameExists(string name, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return false;
    }
}
