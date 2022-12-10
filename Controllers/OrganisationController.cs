using MarketPlays.Entities;
using MarketPlays.Filters;
using MarketPlays.Interfaces;
using MarketPlays.Models.OrgDtos;
using MarketPlays.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MarketPlays.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize]
public class OrganisationController : ControllerBase
{
    private  IOrganisationService organisationService;
    private readonly UserManager<AppUser> userManager;
    public OrganisationController (IOrganisationService _organisationService, UserManager<AppUser> _userManager)
    {
        organisationService = _organisationService;
        userManager = _userManager;
    }

    [HttpPost]
    [ValidateModel]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AddOrganisation(GetOrgDto getOrgDto)
    {
       if (!ModelState.IsValid) throw new Exception();
       await organisationService.AddOrganisation(getOrgDto, User);
       return Ok();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task DeleteOrganisation(Guid Id)
    {
        await organisationService.DeleteOrganisation(Id);
    }

    [HttpGet("{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SendOrgDto))]
    public async Task<ActionResult<SendOrgDto>> GetOrganisation(Guid Id)
    {
        return Ok(await organisationService.GetOrganisation(Id));
    }

    [HttpGet("all")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SendOrgDto>))]
    public async Task<ActionResult<List<SendOrgDto>>> GetOrganisationList()
    {
        return Ok(await organisationService.GetOrganisationList());
    }

    [HttpPut]
    [ValidateModel]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateOrganisation(Guid Id, UpdateOrgDto getOrgDto)
    {
        if (!ModelState.IsValid) throw new Exception();
        await organisationService.UpdateOrganisation(Id, getOrgDto);
        return Ok();
    }
}