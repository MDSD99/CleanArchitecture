using CleanArchitecture.App.Services;
using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.App.Features.CarFeatures.Commands.CreateCar;

internal class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, MessageResponse>
{

    private readonly ICarService _carService;

    public CreateCarCommandHandler(ICarService carService)
    {
        _carService = carService;
    }

    public async Task<MessageResponse> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        await _carService.CreateAsync(request, cancellationToken);
        return new("Araç Üretildi");
    }
}
