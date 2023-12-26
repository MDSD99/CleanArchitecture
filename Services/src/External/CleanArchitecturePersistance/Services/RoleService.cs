using CleanArchitecture.App.Features.RoleFeatures.Commands;
using CleanArchitecture.App.Services;
using CleanArchitecture.Domain.Entites;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecturePersistance.Services
{
    public sealed class RoleService : IRoleService
    {
        private readonly RoleManager<Role> _roleManager;

        public RoleService(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task CreateAsync(CreoateRoleCommand request)
        {
            Role role = new()
            {
                Name = request.Name
            };

            await _roleManager.CreateAsync(role);
        }
    }
}
