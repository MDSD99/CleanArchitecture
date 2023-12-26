
using CleanArchitecture.App.Services;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Infrastructure.Services;
using CleanArchitecture.WebApi.Middleware;
using CleanArchitecturePersistance.Context;
using CleanArchitecturePersistance.Repositories;
using CleanArchitecturePersistance.Services;
using GenericRepository;

namespace CleanArchitecture.WebApi.Configurations
{
    public class PersistanceDIServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder hostBuilder)
        {
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddTransient<ExceptionMiddleware>();
            services.AddScoped<IUnitOfWork, UnitOfWork<AppDbContext>>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IUserRoleService, UserRoleService>();
        }
    }
}
