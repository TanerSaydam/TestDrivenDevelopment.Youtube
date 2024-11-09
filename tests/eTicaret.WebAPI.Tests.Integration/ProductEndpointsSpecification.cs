using eTicaret.Application;
using eTicaret.Domain;
using FluentAssertions;
using System.Net;
using System.Net.Http.Json;

namespace eTicaret.WebAPI.Tests.Integration;

public class ProductEndpointsSpecification : IClassFixture<eTicaretApiFactory>//, IAsyncLifetime
{
    private readonly HttpClient _httpClient;
    private Guid _id = default!;

    public ProductEndpointsSpecification(eTicaretApiFactory apiFactory)
    {
        _httpClient = apiFactory.CreateClient();
    }

    [Fact]
    public async void Create_Should_Be_Return_200_If_Request_Valid_And_Name_Is_Unique()
    {
        // Arrange       
        CreateProductCommand request = new("Laptop", 1);

        // Act
        var response = await _httpClient.PostAsJsonAsync("/products", request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var content = await response.Content.ReadFromJsonAsync<Product>();
        _id = content!.Id;
    }

    [Fact]
    public async void Create_Should_Be_Return_500_If_Request_Not_Valid()
    {
        // Arrange       
        CreateProductCommand request = new("La", 1);

        // Act
        var response = await _httpClient.PostAsJsonAsync("/products", request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    //public async Task DisposeAsync()
    //{
    //    await _httpClient.DeleteAsync($"/products?id={_id}", default);
    //}

    //public Task InitializeAsync() => Task.CompletedTask;
}