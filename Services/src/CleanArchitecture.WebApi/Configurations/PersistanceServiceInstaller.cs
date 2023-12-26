
using CleanArchitecture.Domain.Entites;
using CleanArchitecturePersistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace CleanArchitecture.WebApi.Configurations
{
    public sealed class PersistanceServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder hostBuilder)
        {

            services.AddAutoMapper(typeof(CleanArchitecturePersistance.AssemblyRefence).Assembly);
            string connetiionString = configuration.GetConnectionString("SqlServer");
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connetiionString));
            services.AddIdentity<User, Role>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 1;
                opt.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<AppDbContext>();
            Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Information()
           .Enrich.FromLogContext()
           .WriteTo.Console()
           .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
           .WriteTo.MSSqlServer(
            connectionString: connetiionString,
            tableName: "Logs",
            autoCreateSqlTable: true)
           .CreateLogger();

            hostBuilder.UseSerilog();
        }
    }
}
