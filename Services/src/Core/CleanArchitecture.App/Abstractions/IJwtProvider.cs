using CleanArchitecture.App.Features.AuthFeatres.Commands.Login;
using CleanArchitecture.Domain.Entites;

namespace CleanArchitecture.App.Abstractions
{
    public interface IJwtProvider
    {

        Task<LoginCommandResponse> CreateTokenAsync(User user);

    }
}
