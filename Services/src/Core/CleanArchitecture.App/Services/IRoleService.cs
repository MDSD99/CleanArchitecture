using CleanArchitecture.App.Features.RoleFeatures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.App.Services
{
    public interface IRoleService
    {
       
        Task CreateAsync(CreoateRoleCommand request);
    }
}
