using Microsoft.AspNetCore.Identity;

namespace MarketPlays.Entities;

public class AppUser : IdentityUser<Guid>
{
    public string? FirstName { get; set; }
    public string? LastName  { get; set; }
    public string? Password  { get; set; }
    public string? UserImagePath  { get; set; }
    public EUserStatus UserStatus { get; set; }

    public virtual ICollection<OrganisationUser>? Organisations { get; set; }
}

public enum EUserStatus
{
    created,
    active,
    inactive,
    deleted
}