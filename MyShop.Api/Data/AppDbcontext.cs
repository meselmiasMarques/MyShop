using Microsoft.EntityFrameworkCore;
using MyShop.Core.Model;

namespace MyShop.Api.Data;

public class AppDbcontext(DbContextOptions<AppDbcontext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder mb)
    {
     mb.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);   
    }
}