using CleanArchitecture.App.Features.AuthFeatres.Commands.CreateNewToken;
using CleanArchitecture.App.Features.AuthFeatres.Commands.Login;
using CleanArchitecture.App.Features.AuthFeatres.Commands.Register;

namespace CleanArchitecture.App.Services;

public interface IAuthService
{
    Task RegisterAsync(RegisterCommand request);
    Task<LoginCommandResponse> LoginAsync(LoginCommand request, CancellationToken cancellationToken);
    Task<LoginCommandResponse> CreateTokenRefreshTokenAsync(CreateNewTokenCommand request, CancellationToken cancellationToken);


}
