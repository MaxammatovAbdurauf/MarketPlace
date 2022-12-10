using MarketPlays.Models.UserDtos;

namespace MarketPlays.Interfaces;

public interface IUserService
{
    public Task<SendUserDto> GetUser(Guid userId);
    public Task UpdateUser(Guid userId, UpdateUserDto updateUserDto);
    public Task DeleteUser(Guid userId);
}