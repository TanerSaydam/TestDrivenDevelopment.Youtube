namespace eTicaret.Domain;

public interface IProductRepository
{
    Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    void Delete(Product product);
    Task<bool> IsNameExists(string name, CancellationToken cancellationToken);
    Task CreateAsync(Product product, CancellationToken cancellationToken);
}
