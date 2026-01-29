using Microsoft.EntityFrameworkCore;
using MyShop.Api.Data;
using MyShop.Core.Model;

namespace MyShop.Api.Repositories;

public class CategoryRepository(AppDbcontext db)
{
    private readonly AppDbcontext _db = db;

    public async Task<IList<Category>> GetAsync()
    => await _db.Categories
            .AsNoTracking()
            .ToListAsync();
    
    public async Task<Category?> GetAsync(int id)
    =>  await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);

    public async Task CreateAsync(Category category)
    {
        _db.Categories.Add(category);
        await _db.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(Category model,  int id)
    {
        var category =  await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);

        if (category != null)
            _db.Categories.Update(category);
        await _db.SaveChangesAsync();
        
    }

    public async Task DeleteAsync(int id)
    {
        var category = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
        if (category != null)
            _db.Categories.Remove(category);
        await _db.SaveChangesAsync();
    }
}