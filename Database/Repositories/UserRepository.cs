using Mapster;
using MarketPlays.Database.IRepositories;
using MarketPlays.Entities;
using MarketPlays.Filters;
using MarketPlays.Models.UserDtos;
using Microsoft.EntityFrameworkCore;

namespace MarketPlays.Database.Repositories;

[scoped]
public class UserRepository :IUserRepository
{
    private readonly AppDbContext context;
    public UserRepository (AppDbContext _context)
    {
        context = _context;
    }

    public async Task DeleteUser(Guid userId)
    {
        var user = await context.Users.FirstAsync(u => u.Id == userId);
        context.Remove(user);
        await context.SaveChangesAsync();
    }

    public async Task<SendUserDto> GetUser(Guid userId)
    {
        var user = await context.Users.FirstAsync(u => u.Id == userId);
        return user.Adapt<SendUserDto>();
    }

    public async Task UpdateUser(Guid userId, AppUser appUser)
    {
        var user = await context.Users.FirstAsync(u => u.Id ==userId);
        user.FirstName = appUser.FirstName;
        user.LastName = appUser.LastName;
        user.Email = appUser.Email;
        user.Password = appUser.Password;

        await context.SaveChangesAsync();
    }
}