using System.ComponentModel.DataAnnotations;

namespace MarketPlays.Models.UserDtos;

public class UpdateUserDto
{
    public string? FirstName { get; set; }
    public string? Password { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public IFormFile? UserImage { get; set; }
}