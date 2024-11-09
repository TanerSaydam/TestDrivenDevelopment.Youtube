using eTicaret.Domain;
using eTicaret.Tests.Unit.TestDoubles;
using FluentAssertions;
using NSubstitute;
using TS.Result;

namespace eTicaret.Application;
public sealed class ProductSpecification
{
    private IProductRepository productRepository = Substitute.For<IProductRepository>();
    private IUnitOfWork unitOfWork = new StubUnitOfWork();
    private readonly CreateProductCommandHandler command;
    private readonly CreateProductCommand request = new("Laptop", 1);
    public ProductSpecification()
    {
        command = new(productRepository, unitOfWork);
    }

    //[Fact]
    //public async Task Create_Should_Be_Throw_ProductNameNotValidException_If_Name_Less_Then_3_Characters()
    //{
    //    // Arrange
    //    CreateProductCommand request = new("La", 1);

    //    // Act
    //    var action = async () => await command.Handle(request, default);

    //    // Assert
    //    (await action.Should().ThrowAsync<ProductNameNotValidException>())
    //        .WithMessage("Name must be greater than 3 characters");
    //}


    [Fact]
    public async Task Create_Should_Be_Return_False_If_Name_Less_Then_3_Characters()
    {
        // Arrange
        CreateProductCommand request = new("La", 1);

        // Act
        var response = await command.Handle(request, default);

        // Assert
        response.IsSuccessful.Should().BeFalse();
    }

    //[Theory]
    //[InlineData(0)]
    //[InlineData(-1)]
    //public async Task Create_Should_Be_Throw_ProductPriceNotValidException_If_Price_Equal_Or_Lower_Than_0(decimal price)
    //{
    //    // Arrange
    //    CreateProductCommand request = new("Laptop", price);

    //    // Act
    //    var action = async () => await command.Handle(request, default);

    //    // Assert
    //    (await action.Should().ThrowAsync<ProductPriceNotValidException>())
    //        .WithMessage("Price must be greater than 0");
    //    ;
    //}

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task Create_Should_Be_Return_False_If_Price_Equal_Or_Lower_Than_0(decimal price)
    {
        // Arrange
        CreateProductCommand request = new("Laptop", price);

        // Act
        var response = await command.Handle(request, default);

        // Assert
        response.IsSuccessful.Should().BeFalse();
    }

    //[Fact]
    //public async Task Create_Should_Be_Throw_ProductNameNotUniqueException_If_Name_Not_Unique()
    //{
    //    // Arrange
    //    productRepository.IsNameExists(Arg.Any<string>(), default).Returns(true);

    //    // Act
    //    var action = async () => await command.Handle(request, default);

    //    // Assert
    //    await action.Should().ThrowAsync<ProductNameNotUniqueException>();
    //}

    [Fact]
    public async Task Create_Should_Be_Return_False_If_Name_Not_Unique()
    {
        // Arrange
        productRepository.IsNameExists(Arg.Any<string>(), default).Returns(true);

        // Act
        var response = await command.Handle(request, default);

        // Assert
        response.IsSuccessful.Should().BeFalse();
    }

    [Fact]
    public async Task Create_Should_Be_True_If_Request_Valid_And_Name_Is_Unique()
    {
        // Act
        Result<Product> result = await command.Handle(request, default);

        // Assert
        result.Data!.Name.Should().Be(request.Name);
        result.Data!.Price.Should().Be(request.Price);
    }
}
