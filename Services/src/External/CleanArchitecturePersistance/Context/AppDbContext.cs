using CleanArchitecture.Domain.Abstrations;
using CleanArchitecture.Domain.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace CleanArchitecturePersistance.Context;
public sealed class AppDbContext : IdentityDbContext<User, Role, string>
{
    public AppDbContext(DbContextOptions options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyRefence).Assembly);

        modelBuilder.Ignore<IdentityUserLogin<string>>();
        modelBuilder.Ignore<IdentityUserRole<string>>();
        modelBuilder.Ignore<IdentityUserClaim<string>>();
        modelBuilder.Ignore<IdentityUserToken<string>>();
        modelBuilder.Ignore<IdentityUserClaim<string>>();
        modelBuilder.Ignore<IdentityRole<string>>();
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entites = ChangeTracker.Entries<Entity>();
        foreach (var entite in entites)
        {
            if (entite.State == EntityState.Added) entite.Property(x => x.CreateDate).CurrentValue = DateTime.Now;
            if (entite.State == EntityState.Added) entite.Property(x => x.UpdatedDate).CurrentValue = DateTime.Now;
        }
        return base.SaveChangesAsync(cancellationToken);
    }

}
