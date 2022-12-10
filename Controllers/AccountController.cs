using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MarketPlays.Entities;
using MarketPlays.Filters;
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
    [ValidateModel]
    [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(SendUserDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SignUp(SignUpUserDto signUpUserDto)
    {
        if (await userManager.Users.AnyAsync(x => x.FirstName == signUpUserDto.FirstName))
            return BadRequest("This username is busy");

        var user = signUpUserDto.Adapt<AppUser>();

        await userManager.CreateAsync(user);
        await signInManager.SignInAsync(user, isPersistent: true);
        return Ok(user.Adapt<SendUserDto>());
    }

    [HttpPost("SignIn")]
    [ValidateModel]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SignIn(SignInUserDto signInUserDto)
    {
        if (!await userManager.Users.AnyAsync(x => x.FirstName == signInUserDto.FirstName))
            return BadRequest("Firstname is incorrect");

        var user = await userManager.Users.FirstAsync(x => x.FirstName == signInUserDto.FirstName);

        if (user.Password != signInUserDto.Password)
            return BadRequest("Password is incorrect");

        var result = await signInManager.PasswordSignInAsync(user, user.Password, isPersistent: true, false);

        if (!result.Succeeded)
            return BadRequest("Failed PasswordSignInAsync");

        return Ok("Succeed");
    }
}