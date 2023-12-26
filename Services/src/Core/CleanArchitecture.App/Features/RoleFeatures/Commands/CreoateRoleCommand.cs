using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.App.Features.RoleFeatures.Commands
{
    public sealed record CreoateRoleCommand(string Name) :IRequest<MessageResponse>;
}
