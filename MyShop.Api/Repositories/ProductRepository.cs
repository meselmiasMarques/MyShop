using Microsoft.EntityFrameworkCore;
using MyShop.Api.Data;
using MyShop.Core.Model;

namespace MyShop.Api.Repositories;

public class ProductRepository(AppDbContext db)
{
    private readonly AppDbContext _db = db;

    public async Task<List<Product>> GetAsync()
        => await _db.Products
            .Include(p => p.Category)
            .AsNoTracking()
            .ToListAsync();

    public async Task<Product?> GetAsync(int id)
        => await _db.Products.FirstOrDefaultAsync(c => c.Id == id);

    public async Task CreateAsync(Product product)
    {
        await _db.Products.AddAsync(product);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _db.Products.Update(product);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Product product)
    {
        _db.Products.Remove(product);
        await _db.SaveChangesAsync();
    }
}