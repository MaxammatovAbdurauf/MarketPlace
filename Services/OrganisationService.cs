using MarketPlays.Database;
using MarketPlays.Interfaces;
using MarketPlays.Models.OrgDtos;
using Mapster;
using MarketPlays.Entities;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MarketPlays.Services;

public class OrganisationService : IOrganisationService
{
    private readonly AppDbContext context;
 
    public OrganisationService(AppDbContext _context)
    {
        context     = _context;
    }

    public async Task AddOrganisation(GetOrgDto getOrgDto, ClaimsPrincipal principal)
    {
        var orgId = Guid.NewGuid();
        var userId = Guid.Parse(principal.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var org = new Organisation
        {
            Id = orgId,
            Name = getOrgDto.Name,
            OrgStatus = EOrgStatus.created,
            Users =  new List<OrganisationUser>
            {
                new OrganisationUser
                { 
                    AppUserId      = userId,
                    OrganisationId =  orgId,
                    appUserRole    = EAppUserRole.owner 
                }
            }
        };

        await context.Organisations.AddAsync(org);
        await context.SaveChangesAsync();
    }

    public async Task DeleteOrganisation(Guid Id)
    {
        if (!await context.Organisations.AnyAsync(o => o.Id == Id)) throw new Exception();
        context.Remove(Id);
        await context.SaveChangesAsync();
    }

    public async Task<SendOrgDto> GetOrganisation(Guid Id)
    {
        var orgs = await context.Organisations.FirstAsync(o => o.Id == Id);
        return orgs.Adapt<SendOrgDto>();
    }

    public async Task<List<SendOrgDto>> GetOrganisationList()
    {
        var orgs = await context.Organisations.Select(o => o.Adapt<SendOrgDto>()).ToListAsync();
        return orgs;
    }

    public async Task UpdateOrganisation(Guid Id, UpdateOrgDto updateOrgDto)
    {
        var org = await context.Organisations.FirstAsync(o => o.Id == Id);
        org.Name = updateOrgDto.Name;
        await context.SaveChangesAsync();
    }
}