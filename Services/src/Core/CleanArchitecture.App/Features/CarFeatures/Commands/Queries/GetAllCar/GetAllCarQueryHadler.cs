using CleanArchitecture.App.Services;
using CleanArchitecture.Domain.Entites;
using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.App.Features.CarFeatures.Commands.Queries.GetAllCar
{
    public sealed class GetAllCarQueryHadler : IRequestHandler<GetAllCarQuery, PaginationResult<Car>>
    {
        private readonly ICarService _carService;

        public GetAllCarQueryHadler(ICarService carService)
        {
            _carService = carService;
        }

        public async Task<PaginationResult<Car>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
        {
            PaginationResult<Car> cars = await _carService.GetAllAsync(request, cancellationToken);
            return cars;
        }
    }
}
