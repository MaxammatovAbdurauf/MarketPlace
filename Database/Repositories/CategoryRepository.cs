using Mapster;
using MarketPlays.Entities;
using MarketPlays.Filters;
using MarketPlays.Models.CategoryDtos;
using Microsoft.EntityFrameworkCore;

namespace MarketPlays.Database.Repositories;

[scoped]
public class CategoryRepository
{
    private readonly AppDbContext context;
    public CategoryRepository(AppDbContext _context)
    {
        context = _context;
    }

    public async Task AddCategory(Category category)
    {
        await context.Categories.AddAsync(category);
    }

    public async Task<Category> GetCategory(int categoryId)
    {
        var category = await context.Categories.FirstAsync(c => c.Id == categoryId);
        return category;
    }

    public async Task<List<Category>> GetCategoryList()
    {
       return await context.Categories.Where(c => c.ParentId != null).ToListAsync();
    }

    public async Task UpdateCategory(int categoryId,UpdateCategoryDto updateCategoryDto)
    {
        var category = await context.Categories.FirstAsync(c => c.Id == categoryId);
        category.Name = updateCategoryDto.Name;

        await context.SaveChangesAsync();
    }

    public async Task DeleteCategory(int categoryId)
    {
        var category = await context.Categories.FirstAsync(c => c.Id == categoryId);
        context.Categories.Remove(category);
        await context.SaveChangesAsync();
    }
}