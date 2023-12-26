using CleanArchitecture.App.Features.UserRoleFeatures.Commands.CreateUserRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.App.Services
{
    public interface IUserRoleService
    {
        Task CreateAsync(CreateUserRoleCommand request, CancellationToken cancellationToken);
    }
}
