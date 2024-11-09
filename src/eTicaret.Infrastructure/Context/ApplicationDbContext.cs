using eTicaret.Domain;
using Microsoft.EntityFrameworkCore;

namespace eTicaret.Infrastructure.Context;
public sealed class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}
