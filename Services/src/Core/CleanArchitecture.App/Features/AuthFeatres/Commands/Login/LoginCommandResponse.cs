using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.App.Features.AuthFeatres.Commands.Login
{
    public sealed record LoginCommandResponse(
        string Token,
        string RefreshToken,
        DateTime? RefreshTokenExpires,
        string UserId);
}
