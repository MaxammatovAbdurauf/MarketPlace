using System.ComponentModel.DataAnnotations;

namespace MarketPlays.Models.UserDtos;

public class SignUpUserDto
{
    [Required]
    public string? FirstName { get; set; }
    [Required]
    public string? Password { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
}