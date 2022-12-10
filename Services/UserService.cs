using Mapster;
using MarketPlays.Database.Repositories;
using MarketPlays.Entities;
using MarketPlays.Filters;
using MarketPlays.Interfaces;
using MarketPlays.Models.UserDtos;

namespace MarketPlays.Services;

[scoped]
public class UserService : IUserService
{
    private readonly UserRepository userRepository;
    public UserService(UserRepository _userRepository)
    {
        userRepository = _userRepository;
    }

    public async Task<SendUserDto> GetUser(Guid userId)
    {
        var user =await userRepository.GetUser(userId);
        return new SendUserDto();
    }

    public async Task UpdateUser(Guid userId, UpdateUserDto updateUserDto)
    {
       var userImage = FileService.SaveImage(updateUserDto.UserImage, "ProfileImage");
       var appUser = updateUserDto.Adapt<AppUser>();
       appUser.UserImagePath = userImage;
       await userRepository.UpdateUser(userId, appUser);
    }

    public async Task DeleteUser(Guid userId)
    {
        await userRepository.DeleteUser(userId);
    }
}