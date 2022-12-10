using MarketPlays.Filters;
using MarketPlays.Interfaces;
using MarketPlays.Models.CategoryDtos;
using MarketPlays.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace MarketPlays.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService categoryService;
    public CategoryController(ICategoryService _categoryService)
    {
        categoryService = _categoryService;
    }

    [HttpPost]
    [ValidateModel]
    [ProducesResponseType(statusCode:200)]
    public async Task<IActionResult> AddCategory(GetCategoryDto getCategoryDto)
    {
        await categoryService.AddCategory(getCategoryDto);
        return Ok();
    }

    [HttpGet("{Id}")]
    [ProducesResponseType(statusCode: 200, Type = typeof(SendCategoryDto))]
    public async Task<ActionResult<SendCategoryDto>> GetCategory(int categoryId)
    {
        return Ok(await categoryService.GetCategory(categoryId));
    }

    [HttpGet("all")]
    [ProducesResponseType(statusCode: 200, Type = typeof(List<SendCategoryDto>))]
    public async Task<ActionResult <List<SendCategoryDto>>> GetCategoryList()
    {
        return Ok (await categoryService.GetCategoryList());
    }

    [HttpPut]
    [ValidateModel]
    [ProducesResponseType(statusCode: 200)]
    public async Task<IActionResult> UpdateCategory(int categoryId, UpdateCategoryDto updateCategoryDto)
    {
        await categoryService.UpdateCategory(categoryId, updateCategoryDto);
        return Ok();
    }

    [HttpDelete]
    [ProducesResponseType(statusCode: 200)]
    public async Task<IActionResult> DeleteCategory(int categoryId)
    {
        await categoryService.DeleteCategory(categoryId);
        return Ok();
    }
}