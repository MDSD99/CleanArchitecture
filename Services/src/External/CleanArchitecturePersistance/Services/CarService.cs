using AutoMapper;
using CleanArchitecture.App.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.App.Features.CarFeatures.Commands.Queries.GetAllCar;
using CleanArchitecture.App.Services;
using CleanArchitecture.Domain.Entites;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecturePersistance.Context;
using EntityFrameworkCorePagination.Nuget.Pagination;
using GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecturePersistance.Services;

public sealed class CarService : ICarService
{
    private readonly AppDbContext _appDbContext;
    private readonly ICarRepository _carService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CarService(AppDbContext appDbContext, IMapper mapper, ICarRepository carService = null, IUnitOfWork unitOfWork = null)
    {
        _appDbContext = appDbContext;
        _mapper = mapper;
        _carService = carService;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(CreateCarCommand request, CancellationToken cancellationToken)
    {
        Car car = _mapper.Map<Car>(request);
        //await _appDbContext.Set<Car>().AddAsync(car, cancellationToken);
        //await _appDbContext.SaveChangesAsync(cancellationToken);
        await _carService.AddAsync(car, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<PaginationResult<Car>> GetAllAsync(GetAllCarQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<Car> cars = await _carService
        .GetWhere(x => x.Name.ToLower()
        .Contains(request.Search.ToLower()))
        .OrderBy(x => x.Name)
        .ToPagedListAsync(request.PageNumber,request.PageSize,cancellationToken);
        return cars;
    }
}
