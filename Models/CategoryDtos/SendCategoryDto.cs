using MarketPlays.Entities;

namespace MarketPlays.Models.CategoryDtos;

public class SendCategoryDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<Product>? Products { get; set; }
    public List<Category>? Children { get; set; }
}