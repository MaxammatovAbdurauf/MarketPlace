namespace MarketPlays.Models.UserDtos;

public class SendUserDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public IFormFile? UserImage { get; set; }
}