using System.ComponentModel.DataAnnotations;

namespace MarketPlays.Models.CategoryDtos;

public class UpdateCategoryDto
{
    public string? Name { get; set; }
    public int? ParentId { get; set; }
}