using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MarketPlays.Entities;
using MarketPlays.Models.UserDtos;
using Microsoft.EntityFrameworkCore;
using Mapster;

namespace MarketPlays.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly SignInManager<AppUser> signInManager;
    private readonly UserManager<AppUser> userManager;

    public AccountController(SignInManager<AppUser> _signInManager,
                              UserManager<AppUser>  _userManager)
    {
        signInManager = _signInManager;
        userManager   = _userManager;
    }

    [HttpPost("SignUp")]
    public async Task<IActionResult> SignUp(SignUpUserDto signUpUserDto)
    {
        if (!ModelState.IsValid)
            return BadRequest("Dto not valid");

        if (await userManager.Users.AnyAsync(x => x.UserName == signUpUserDto.UserName))
            return BadRequest("Username is busy");

        var user = signUpUserDto.Adapt<AppUser>();

        await userManager.CreateAsync(user);
        await signInManager.SignInAsync(user, isPersistent: true);
        return Ok(user.Adapt<SendUserDto>());
    }

    [HttpPost("SignIn")]
    public async Task<IActionResult> SignIn(SignInUserDto signInUserDto)
    {
        if (!ModelState.IsValid)
            return BadRequest("Dto not valid");

        if (!await userManager.Users.AnyAsync(x => x.UserName == signInUserDto.UserName))
            return BadRequest("Username is incorrect");

        var user = await userManager.Users.FirstAsync(x => x.UserName == signInUserDto.UserName);

        if (user.Password != signInUserDto.Password)
            return BadRequest("Password is incorrect");

        var result = await signInManager.PasswordSignInAsync(user, user.Password, isPersistent: true, false);

        if (!result.Succeeded)
            return BadRequest("Failed PasswordSignInAsync");

        return Ok("Succeed");
    }
}