using MarketPlays.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MarketPlays.Database;

public class AppDbContext :  IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
{
    public AppDbContext(DbContextOptions<AppDbContext>options) : base(options) { }
    public DbSet<Organisation> Organisations { get; set; }
    public DbSet<OrganisationUser> OrganisationUsers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<OrganisationUser>().HasKey(orgUser => new {orgUser.OrganisationId, orgUser.AppUserId});
    }
}