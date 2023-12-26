using CleanArchitecture.Domain.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Authorization
{
    public sealed class RoleAttibute : Attribute, IAuthorizationFilter
    {
        private readonly string _role;
        private readonly IUserRoleRepository _userRoleRepository;
        public RoleAttibute(string role, IUserRoleRepository userRoleRepository = null)
        {
            _role = role;
            _userRoleRepository = userRoleRepository;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userIdClaim = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            var userHasRole = _userRoleRepository.GetWhere(x=>x.UserId==userIdClaim.Value)
                .Include(x=>x.Role).Any(x=>x.Role.Name==_role);

            if (!userHasRole)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
