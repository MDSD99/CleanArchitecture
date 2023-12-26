using CleanArchitecture.Domain.Abstrations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entites;

public sealed class UserRole : Entity
{
    [ForeignKey("User")]
    public string UserId { get; set; }
    public User User { get; set; }

    [ForeignKey("Role")]
    public string RoleId { get; set; }
    public Role Role { get; set; }
}
