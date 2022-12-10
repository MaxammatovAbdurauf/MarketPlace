using Mapster;
using MarketPlays.Database;
using MarketPlays.Entities;
using MarketPlays.Extensions.AddServiceFromAttribute;
using MarketPlays.Interfaces;
using MarketPlays.Models.OrgDtos;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MarketPlays.Services;

[Scoped]
public class OrganisationService : IOrganisationService
{
    private readonly AppDbContext context;
    public OrganisationService(AppDbContext _context)
    {
        context = _context;
    }

    public async Task AddOrganisation(GetOrgDto getOrgDto, ClaimsPrincipal principal)
    {
        var orgId = Guid.NewGuid();
        var userId = Guid.Parse(principal.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var imagePath = FileService.SaveImage(getOrgDto.OrganisationImage, "OrganisationImage");

        var org = new Organisation
        {
            Id = orgId,
            Name = getOrgDto.Name,
            OrgStatus = EOrgStatus.created,
            OrgImagePath = imagePath,
            Users = new List<OrganisationUser>
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

    public async Task DeleteOrganisation(Guid productId)
    {
        if (!await context.Organisations.AnyAsync(o => o.Id == productId)) throw new Exception();
        var org = await context.Organisations.FirstAsync(o => o.Id == productId);
        context.Remove(org);
        await context.SaveChangesAsync();
    }

    public async Task<SendOrgDto> GetOrganisation(Guid productId)
    {
        var orgs = await context.Organisations.FirstAsync(o => o.Id == productId);
        return orgs.Adapt<SendOrgDto>();
    }

    public async Task<List<SendOrgDto>> GetOrganisationList()
    {
        var orgs = await context.Organisations.Select(o => o.Adapt<SendOrgDto>()).ToListAsync();
        return orgs;
    }

    public async Task UpdateOrganisation(Guid productId, UpdateOrgDto updateOrgDto)
    {
        var org = await context.Organisations.FirstAsync(o => o.Id == productId);
        var imagePath = FileService.SaveImage(updateOrgDto.OrganisationImage, "OrganisationImage");
        org.Name = updateOrgDto.Name;
        org.OrgImagePath = imagePath;
        await context.SaveChangesAsync();
    }
}