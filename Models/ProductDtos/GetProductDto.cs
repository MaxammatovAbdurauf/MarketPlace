using System.ComponentModel.DataAnnotations;

namespace MarketPlays.Models.ProductDtos;

public class GetProductDto
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public decimal? Price { get; set; }
    public string? Description { get; set; }
    public bool? OnSale { get; set; }
    public uint Count { get; set; }
    public IFormFile? ProductImage { get; set; }
    public Dictionary<string, string>? Properties { get; set; }
}