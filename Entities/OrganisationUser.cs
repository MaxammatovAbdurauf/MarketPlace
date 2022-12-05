using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlays.Entities;

public class OrganisationUser
{
    public EAppUserRole appUserRole { get; set; }
    public Guid AppUserId { get; set; }
    [ForeignKey(nameof(AppUserId))]
    public  virtual AppUser? appUser { get; set; }

    public Guid OrganisationId { get; set; }
    [ForeignKey(nameof(OrganisationId))]
    public virtual Organisation? organisation { get; set; }
}

public enum EAppUserRole
{
    owner,
    manager,
    seller
}