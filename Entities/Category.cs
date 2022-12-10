using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlays.Entities;

public class Category
{
    public int Id           { get; set; }
    public string? Name     { get; set; }

    public int? ParentId     { get; set; }
    [ForeignKey(nameof(ParentId))]
    public Category? Parent { get; set; }

    public List<Product>? Products   { get; set; }
    public List <Category>? Children { get; set; }
}