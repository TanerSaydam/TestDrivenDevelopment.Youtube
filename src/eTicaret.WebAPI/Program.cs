using eTicaret.Application;
using eTicaret.Application.Features.Products;
using eTicaret.Infrastructure;
using eTicaret.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration, builder.Environment.IsEnvironment("Test"));

var app = builder.Build();

app.MapPost("/products", async (CreateProductCommand request, IMediator mediator, CancellationToken cancellationToken) =>
{
    var response = await mediator.Send(request, cancellationToken);
    return response.IsSuccessful ? Results.Ok(response.Data!) : Results.BadRequest(response.ErrorMessages);
});

app.MapDelete("/products", async (Guid id, IMediator mediator, CancellationToken cancellationToken) =>
{
    DeleteProductByIdCommand request = new(id);
    await mediator.Send(request, cancellationToken);
    return Results.Ok();
});

using (var scoped = app.Services.CreateScope())
{
    var dbContext = scoped.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

app.Run();
