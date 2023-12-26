using CleanArchitecture.App.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Presentation.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CleanArchitecture.UnitTest
{
    public class CarsControllerUnitTest
    {
        [Fact]
        public async void Create_ReturnsOkReult_WhenRequestValid()
        {

            var mediator = new Mock<IMediator>();
            CreateCarCommand createCarCommm = new(
                "Toyota", "Crolla",5000);
            MessageResponse response = new("Araç Baþarýla Kaydedildi");
            CancellationToken cancellationToken = new();
            mediator.Setup(x=>x.Send(createCarCommm,cancellationToken)).ReturnsAsync(response);
            CarsController carsController = new(mediator.Object);
            var result = await carsController.Create(createCarCommm, cancellationToken);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<MessageResponse>(okResult.Value);
            Assert.Equal(response,returnValue);
            mediator.Verify(x=>x.Send(createCarCommm,cancellationToken),Times.Once);
        }
    }
}