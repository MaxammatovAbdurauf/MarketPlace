using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlays.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize]
public class ProfileController : ControllerBase
{
    [HttpGet]
    public async Task <IActionResult> GetUser ()
    {
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser()
    {
        return Ok();
    }
}