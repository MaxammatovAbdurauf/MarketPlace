using MarketPlays.Database;
using MarketPlays.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MarketPlays.Extensions;

public  static class ServiceCollection
{
    public static void _AddCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(options =>
            {
                options.AllowAnyHeader().AllowAnyOrigin().AllowAnyOrigin();
            });
        });
    }

    public static void _AddDbContext (this IServiceCollection services, string connetionstring)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(connetionstring);
        });
    }

    public static void _AddIdentity(this IServiceCollection services)
    {
        services.AddIdentity<AppUser, IdentityRole<Guid>>(options =>
        {
            options.Password.RequiredUniqueChars = 1;
            options.Password.RequiredLength = 4;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
        })
                .AddEntityFrameworkStores<AppDbContext>();
    }
}