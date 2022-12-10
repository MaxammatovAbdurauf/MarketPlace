using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlays.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public decimal? Price { get; set; }
    public uint Count { get; set; }
    public bool? OnSale { get; set; }
    public bool? OnTrend { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? Description { get; set; }
    public string? ProductImagePath { get; set; }
    public Dictionary<string, string>? Properties { get; set; }

    public Guid organisationId { get; set; }
    [ForeignKey(nameof(organisationId))]
    public Organisation? organisation { get; set; }
}