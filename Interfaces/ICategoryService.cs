using MarketPlays.Models.CategoryDtos;

namespace MarketPlays.Interfaces;

public interface ICategoryService
{
    Task AddCategory(GetCategoryDto getCategoryDto);
    Task<SendCategoryDto> GetCategory(int categoryId);
    Task<List<SendCategoryDto>> GetCategoryList();
    Task UpdateCategory(int categoryId,UpdateCategoryDto updateCategoryDto);
    Task DeleteCategory(int categoryId);
}