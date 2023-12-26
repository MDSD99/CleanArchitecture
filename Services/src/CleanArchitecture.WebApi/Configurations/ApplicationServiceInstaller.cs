
using CleanArchitecture.App.Behaviors;
using FluentValidation;
using MediatR;

namespace CleanArchitecture.WebApi.Configurations
{
    public class ApplicationServiceInstaller : IServiceInstaller
    {

        public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder hostBuilder)
        {
            services.AddMediatR(cfr => cfr.RegisterServicesFromAssembly(typeof(CleanArchitecture.App.AssemblyReference).Assembly));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
            services.AddValidatorsFromAssembly(typeof(CleanArchitecture.App.AssemblyReference).Assembly);
        }
    }
}
