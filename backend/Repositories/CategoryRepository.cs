using backend.DTO;
using backend.Models;
using backend.Services;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories;

public class CategoryRepository (ApplicationDbContext context)
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<Category>> GetCategories()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category> Save(CategoryDTO category)
    {
        var newCategory = new Category
        {
            Name = category.Name
        };

        _context.Categories.Add(newCategory );
        await _context.SaveChangesAsync();
    
        return newCategory;
    }

}