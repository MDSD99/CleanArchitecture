using MediatR;

namespace CleanArchitecture.App.Features.AuthFeatres.Commands.Login
{
    public sealed record LoginCommand(
  string UserNameOrEmail,
    string Password) : IRequest<LoginCommandResponse>;
}
