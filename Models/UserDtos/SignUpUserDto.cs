using System.ComponentModel.DataAnnotations;

namespace MarketPlays.Models.UserDtos;

public class SignUpUserDto
{
    [Required]
    public string? UserName { get; set; }
    [Required]
    public string? Password { get; set; }
}