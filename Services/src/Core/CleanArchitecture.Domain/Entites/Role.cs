using Microsoft.AspNetCore.Identity;
namespace CleanArchitecture.Domain.Entites;

public sealed class Role : IdentityRole<string>
{
    public Role()
    {
        Id = Guid.NewGuid().ToString();
    }
}
