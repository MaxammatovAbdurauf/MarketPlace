using System.ComponentModel.DataAnnotations;

namespace MarketPlays.Models.OrgDtos;

public class GetOrgDto
{
    [Required]
    public string? Name { get; set; }
}