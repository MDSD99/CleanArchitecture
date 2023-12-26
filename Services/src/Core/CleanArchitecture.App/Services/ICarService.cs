using CleanArchitecture.App.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.App.Features.CarFeatures.Commands.Queries.GetAllCar;
using CleanArchitecture.Domain.Entites;
using EntityFrameworkCorePagination.Nuget.Pagination;
using System.Threading;

namespace CleanArchitecture.App.Services;

public interface ICarService
{
    Task CreateAsync(CreateCarCommand request, CancellationToken cancellationToken);
    Task<PaginationResult<Car>> GetAllAsync(GetAllCarQuery request, CancellationToken cancellationToken);
    
}
