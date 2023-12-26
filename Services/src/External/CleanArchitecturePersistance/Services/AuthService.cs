using AutoMapper;
using CleanArchitecture.App.Abstractions;
using CleanArchitecture.App.Features.AuthFeatres.Commands.CreateNewToken;
using CleanArchitecture.App.Features.AuthFeatres.Commands.Login;
using CleanArchitecture.App.Features.AuthFeatres.Commands.Register;
using CleanArchitecture.App.Services;
using CleanArchitecture.Domain.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace CleanArchitecturePersistance.Services;
public sealed class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    private readonly IMailService _mailService;
    private readonly IJwtProvider _jwtProvider;
    public AuthService(UserManager<User> userManager, IMapper mapper, IMailService mailService = null, IJwtProvider jwtProvider = null)
    {
        _userManager = userManager;
        _mapper = mapper;
        _mailService = mailService;
        _jwtProvider = jwtProvider;
    }
    public async Task<LoginCommandResponse> CreateTokenRefreshTokenAsync(CreateNewTokenCommand request, CancellationToken cancellationToken)
    {
        User user = await _userManager.FindByIdAsync(request.UserId);
        if (user == null) throw new Exception("Kullanıcı Bulunamadı");
        if (user.RefreshToken != request.RefreshToken) throw new Exception("Refresh token geçerli değil");
        if (user.RefreshTokenExpires < DateTime.Now) throw new Exception("Refrssh Token Süresi Bitti");
        LoginCommandResponse response = await _jwtProvider.CreateTokenAsync(user);
        return response;
    }
    public async Task<LoginCommandResponse> LoginAsync(LoginCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userManager.Users.Where(
        x => x.UserName == request.UserNameOrEmail
        || x.Email == request.UserNameOrEmail)
       .FirstOrDefaultAsync(cancellationToken);
        if (user == null) throw new Exception("Kullanıcı Bulunamadı");
        await _userManager.CheckPasswordAsync(user, request.Password);
        if (user == null)
        {
            LoginCommandResponse response = await _jwtProvider.CreateTokenAsync(user);
        }
        throw new Exception("Şifreniz Yanliş");
    }
    public async Task RegisterAsync(RegisterCommand request)
    {
        User user = _mapper.Map<User>(request);
        IdentityResult result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.First().Description);
        }
        List<string> emails = new();
        emails.Add(request.Email);
        string body = "";
        //await _mailService.SendMailAsync(emails, "Email Onay", body);
    }
}
