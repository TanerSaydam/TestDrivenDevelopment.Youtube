using eTicaret.Domain;
using MediatR;
using TS.Result;

namespace eTicaret.Application;

public sealed record CreateProductCommand(string Name, decimal Price) : IRequest<Result<Product>>;

public sealed class CreateProductCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateProductCommand, Result<Product>>
{
    public async Task<Result<Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        if (request.Name.Length < 3)
        {
            return Result<Product>.Failure("Name must be greater than 3 characters");
        }

        if (request.Price <= 0)
        {
            return Result<Product>.Failure("Price must be greater than 0");
        }

        var isNameExists = await productRepository.IsNameExists(request.Name, cancellationToken);

        if (isNameExists)
        {
            return Result<Product>.Failure("Name already using");
        }

        Product product = new()
        {
            Name = request.Name,
            Price = request.Price
        };

        await productRepository.CreateAsync(product, cancellationToken);
        var result = await unitOfWork.SaveChangesAsync(cancellationToken);

        return product;
    }
}