using CleanArchitecture.Domain.Entites;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecturePersistance.Context;
using GenericRepository;

namespace CleanArchitecturePersistance.Repositories;

public sealed class UserRoleRepository : Repository<UserRole, AppDbContext>, IUserRoleRepository
{
    public UserRoleRepository(AppDbContext context) : base(context)
    {
    }
}