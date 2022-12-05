using System.ComponentModel.DataAnnotations;

namespace MarketPlays.Models.UserDtos;

public class SignInUserDto
{
    [Required] // [Remote("")] // java script codlari yordamida ishlidi mvc 
    public string? UserName  { get; set; }
    [Required]
    public string? Password  { get; set; }
    [Required]
    public string? FirstName { get; set; }
    public string? LastName  { get; set; }
    public string?  Email    { get; set; } 
}