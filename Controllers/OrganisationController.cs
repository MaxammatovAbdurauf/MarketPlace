using MarketPlays.Entities;
using MarketPlays.Interfaces;
using MarketPlays.Models.OrgDtos;
using MarketPlays.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MarketPlays.Controllers;

[Route("[controller]")]
[ApiController]
public class OrganisationController : ControllerBase
{
    private readonly OrganisationService organisationService;
    private readonly UserManager<AppUser> userManager;
    public OrganisationController (OrganisationService _organisationService, UserManager<AppUser> _userManager)
    {
        organisationService = _organisationService;
        userManager = _userManager;
    }

    [HttpPost]
    public async Task AddOrganisation(GetOrgDto getOrgDto)
    {
       if (!ModelState.IsValid) throw new Exception();
        await organisationService.AddOrganisation(getOrgDto, User);
    }

    [HttpDelete]
    public async Task DeleteOrganisation(Guid Id)
    {
        await organisationService.DeleteOrganisation(Id);
    }

    [HttpGet("one")]
    public async Task<SendOrgDto> GetOrganisation(Guid Id)
    {
        return await organisationService.GetOrganisation(Id);
    }

    [HttpGet("all")]
    public async Task<List<SendOrgDto>> GetOrganisationList()
    {
        return await organisationService.GetOrganisationList();
    }

    [HttpPut]
    public async Task UpdateOrganisation(Guid Id, UpdateOrgDto getOrgDto)
    {
        if (!ModelState.IsValid) throw new Exception();
        await organisationService.UpdateOrganisation(Id, getOrgDto);
    }
}