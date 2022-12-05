using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlays.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public Guid organisationId { get; set; }
    [ForeignKey(nameof(organisationId))]
    public Organisation? organisation { get; set; }
}