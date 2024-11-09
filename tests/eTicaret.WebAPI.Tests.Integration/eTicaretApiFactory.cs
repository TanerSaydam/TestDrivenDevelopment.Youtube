using eTicaret.Infrastructure.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Testcontainers.PostgreSql;

namespace eTicaret.WebAPI.Tests.Integration;
public sealed class eTicaretApiFactory : WebApplicationFactory<IApiMarker>, IAsyncLifetime
{
    private readonly PostgreSqlContainer postgreSqlContainer = new PostgreSqlBuilder().Build();

    public eTicaretApiFactory()
    {
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Test");
    }
    public async Task InitializeAsync()
    {
        await postgreSqlContainer.StartAsync();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                string connectionString = postgreSqlContainer.GetConnectionString();
                options.UseNpgsql(connectionString);
            });

        });
    }

    public async new Task DisposeAsync()
    {
        await postgreSqlContainer.DisposeAsync();
    }
}
