
using CleanArchitecture.Domain.Entites;
using CleanArchitecturePersistance.Context;
using FluentValidation;

namespace CleanArchitecture.WebApi.Middleware
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly AppDbContext _appDbContext;

        public ExceptionMiddleware(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await LogExceptionToDatabaseAsync(ex,context.Request);
                await HandleExceptitonAsync(context, ex);

            }
        }

        private Task HandleExceptitonAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;
            if (ex.GetType() == typeof(ValidationException))
            {
                return context.Response.WriteAsync(new ValidationErrorDetail
                {
                    Errors = ((ValidationException)ex).Errors.Select(x => x.PropertyName),
                    StatusCode = 403
                }.ToString());
            }
            return context.Response.WriteAsync(new ErrorResult
            {
                Message = ex.Message,
                StatusCode = context.Response.StatusCode
            }.ToString());
        }

        private async Task LogExceptionToDatabaseAsync(Exception ex,HttpRequest request)
        {
            ErrorLog errorLog = new()
            {
                ErrorMessage = ex.Message,
                SackTrace = ex.StackTrace,
                RequestPath = request.Path,
                RequestMethod = request.Method,
                Tİmestamp = DateTime.Now,
            };
            await _appDbContext.Set<ErrorLog>().AddAsync(errorLog, default);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
