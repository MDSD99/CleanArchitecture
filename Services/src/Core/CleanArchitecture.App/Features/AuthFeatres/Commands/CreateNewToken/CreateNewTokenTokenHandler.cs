using CleanArchitecture.App.Features.AuthFeatres.Commands.Login;
using CleanArchitecture.App.Services;
using MediatR;
namespace CleanArchitecture.App.Features.AuthFeatres.Commands.CreateNewToken
{
    public sealed class CreateNewTokenTokenHandler : IRequestHandler<CreateNewTokenCommand, LoginCommandResponse>
    {
        private readonly IAuthService _authService;
        public CreateNewTokenTokenHandler(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<LoginCommandResponse> Handle(CreateNewTokenCommand request, CancellationToken cancellationToken)
        {
            LoginCommandResponse response = await _authService.CreateTokenRefreshTokenAsync(request, cancellationToken);
            return response;
        }
    }
}
