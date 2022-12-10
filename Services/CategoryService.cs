using Mapster;
using MarketPlays.Database.Repositories;
using MarketPlays.Entities;
using MarketPlays.Filters;
using MarketPlays.Interfaces;
using MarketPlays.Models.CategoryDtos;

namespace MarketPlays.Services;

[scoped]
public class CategoryService : ICategoryService
{
    private readonly CategoryRepository categoryRepository;
    public CategoryService(CategoryRepository _categoryRepository)
    {
        categoryRepository = _categoryRepository;
    }

    public async Task AddCategory(GetCategoryDto getCategoryDto)
    {
        var category = getCategoryDto.Adapt<Category>();
        await categoryRepository.AddCategory(category);
    } //ketti

    public async Task<SendCategoryDto> GetCategory(int categoryId)
    {
        var category = await categoryRepository.GetCategory(categoryId);
        return ConvertToDto(category);
    } //

    public async Task<List<SendCategoryDto>> GetCategoryList() 
    {
        var categoryList = await categoryRepository.GetCategoryList();
        if (categoryList is null) throw new Exception("categoryList is empty");

        var categoryDtoList = new List<SendCategoryDto>();
        foreach (var category in categoryList)
        {
            var categoryDto = ConvertToDto(category);
            categoryDtoList.Add(categoryDto);   
        }

        return categoryDtoList;
    }

    public async Task UpdateCategory(int categoryId, UpdateCategoryDto updateCategoryDto)
    {
        await categoryRepository.UpdateCategory(categoryId, updateCategoryDto);
    }

    public async Task DeleteCategory(int categoryId)
    {
        await categoryRepository.DeleteCategory(categoryId);
    }

    private SendCategoryDto ConvertToDto(Category category)
    {
        SendCategoryDto dto = new SendCategoryDto
        {
            Name = category.Name,
        };
        
        if (category.Children is null) return dto;

        foreach (var child in category.Children)
        {
            //dto.Children ??= new List<SendCategoryDto>();
           // dto.Children.Add(ConvertToDto(child));
        }

        return dto;
    }
}