using MarketPlays.Models.CategoryDtos;
using MarketPlays.Models.OrgDtos;

namespace MarketPlays.Models.ProductDtos;

public class SendProductDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public bool? OnSale { get; set; }
    public uint Count { get; set; }
    public DateTime? CreatedDate { get; set; }
    public IFormFile? ProductImage { get; set; }
    public Dictionary<string, string>? Properties { get; set; }

    public virtual SendCategoryDto? Category { get; set; }
    public virtual SendOrgDto? Org { get; set; }
}