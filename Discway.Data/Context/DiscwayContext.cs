using Discway.Data.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Discway.Data.Context;

public class DiscwayContext : IdentityDbContext<User>
{
    public DiscwayContext(DbContextOptions<DiscwayContext> options)
        : base(options)
    {

    }
    public DbSet<Tag> Tag { get; set; }

    public DbSet<League> League { get; set; }

    public DbSet<UserLeague> UserLeague { get; set; }

    //Overrides default table names
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>(entity => { entity.ToTable("User"); });

        builder.Entity<IdentityRole>(entity => { entity.ToTable("Role"); });

        builder.Entity<IdentityUserRole<string>>(entity => { entity.ToTable("UserRole"); });

        builder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable("RoleClaim"); });

        builder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable("UserClaim"); });

        builder.Entity<IdentityUserLogin<string>>(entity => { entity.ToTable("UserLogin"); });

        builder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable("UserToken"); });
    }
}