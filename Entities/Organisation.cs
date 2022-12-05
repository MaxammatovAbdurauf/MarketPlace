namespace MarketPlays.Entities;

public class Organisation
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public EOrgStatus OrgStatus { get; set; }

    public virtual ICollection <OrganisationUser>? Users { get; set; }
}

public enum EOrgStatus
{
    created,
    deleted
}