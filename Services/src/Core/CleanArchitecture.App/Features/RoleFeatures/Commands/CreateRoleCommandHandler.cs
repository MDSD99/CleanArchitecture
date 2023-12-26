using CleanArchitecture.App.Services;
using CleanArchitecture.Domain.Dtos;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.App.Features.RoleFeatures.Commands
{
    public sealed class CreateRoleCommandHandler : IRequestHandler<CreoateRoleCommand, MessageResponse>
    {
        private readonly IRoleService _roleService;

        public CreateRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<MessageResponse> Handle(CreoateRoleCommand request, CancellationToken cancellationToken)
        {
            await _roleService.CreateAsync(request);
            return new("Role Kaydı Tamamlandı");
        }
    }
}
//using CleanArchitecture.App.Services;
//using CleanArchitecture.Domain.Dtos;
//using MediatR;
//using MediatR.Pipeline;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CleanArchitecture.App.Features.RoleFeatures.Commands
//{
//    public sealed class CreateRoleCommandHandler : IRequestHandler<CreoateRoleCommand, MessageResponse>
//    {
//        private readonly IUserRolServive _roleService;

//        public CreateRoleCommandHandler(IUserRolServive roleService)
//        {
//            _roleService = roleService;
//        }

//        public async Task<MessageResponse> Handle(CreoateRoleCommand request, CancellationToken cancellationToken)
//        {
//            await _roleService.CreateAsync(request);
//            return new("Role Kaydı Tamamlandı");
//        }
//    }
//}
