using System.ComponentModel.DataAnnotations;

namespace MarketPlays.Models.UserDtos;

public class SignInUserDto
{
    [Required] // [Remote("")] // java script codlari yordamida ishlidi mvc 
    public string? FirstName  { get; set; }
    [Required]
    public string? Password  { get; set; }
}