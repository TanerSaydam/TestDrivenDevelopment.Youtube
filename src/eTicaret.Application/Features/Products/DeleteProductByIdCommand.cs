using eTicaret.Domain;
using MediatR;

namespace eTicaret.Application.Features.Products;
public sealed record DeleteProductByIdCommand(
    Guid Id) : IRequest;


internal sealed class DeleteProductByIdCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteProductByIdCommand>
{
    public async Task Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
    {
        Product product = await productRepository.GetByIdAsync(request.Id, cancellationToken);

        productRepository.Delete(product);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
