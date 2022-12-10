using MarketPlays.Entities;
using MarketPlays.Filters;
using MarketPlays.Interfaces;
using MarketPlays.Models.UserDtos;
using MarketPlays.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlays.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService userService;
    private readonly UserManager<AppUser> userManager;
    public UserController (IUserService _userService, UserManager<AppUser> _userManager)
    {
        userService = _userService;
        userManager = _userManager;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SendUserDto))]
    public async Task <IActionResult> GetUser ()
    {
        var user = await userManager.GetUserAsync(User);
        return Ok (await userService.GetUser(user.Id));
    }

    [HttpPut]
    [ValidateModel]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateUser([FromForm]UpdateUserDto updateUserDto)
    {
        var user = await userManager.GetUserAsync(User);
        await userService.UpdateUser(user.Id, updateUserDto);
        return Ok();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteUser()
    {
        var user = await userManager.GetUserAsync(User);
        await userService.DeleteUser(user.Id);
        return Ok();
    }
}