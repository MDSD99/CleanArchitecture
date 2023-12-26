using CleanArchitecture.WebApi.Configurations;
using CleanArchitecture.WebApi.Middleware;
namespace CleanArchitecture.WebApi;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services
    .InstallServices(
    builder.Configuration,
    builder.Host,
    typeof(IServiceInstaller).Assembly);


        var app = builder.Build();
        if (app.Environment.IsDevelopment()) { app.UseSwagger(); app.UseSwaggerUI(); }
        app.UseCors();
        app.UseMiddlewareExtensions();
        app.UseHttpsRedirection();
        app.MapControllers();
        app.Run();
    }
}
