using CleanArchitecture.App.Features.AuthFeatres.Commands.Login;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.App.Features.AuthFeatres.Commands.CreateNewToken
{
    public sealed record CreateNewTokenCommand
        (
        string UserId, string RefreshToken
        ) : IRequest<LoginCommandResponse>;

}
