using MarketPlays.Models.OrgDtos;
using System.Security.Claims;

namespace MarketPlays.Interfaces;

public interface IOrganisationService
{
    Task AddOrganisation(GetOrgDto getOrgDto, ClaimsPrincipal principal);
    Task<SendOrgDto> GetOrganisation(Guid Id);
    Task<List<SendOrgDto>> GetOrganisationList();
    Task UpdateOrganisation(Guid Id, UpdateOrgDto getOrgDto);
    Task DeleteOrganisation(Guid Id);
}