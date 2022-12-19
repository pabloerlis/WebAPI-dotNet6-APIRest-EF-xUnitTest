using Microsoft.AspNetCore.Mvc;
using Moq;
using Sale.Api.Controllers;
using Sale.Application.Interfaces;
using Sale.Domain.Models;
using System.Threading.Tasks;
using Xunit;

namespace Sale.UnitTest;

public class SaleControllerTest
{
    [Fact]
    public async Task Post_ReturnsAObject_WhenModelStateIsValid()
    {
        // Arrange
        var mockRepo = new Mock<ISaleService>();
        mockRepo.Setup(service => service.AddAsync(It.IsAny<Vendas_Produto>()))
            .Returns(Task.CompletedTask)
            .Verifiable();
        var controller = new SaleController(mockRepo.Object);
        var newSession = new Vendas_Produto
        {
           Id = 1
        };

        // Act
        var result = await controller.Post(newSession);

        // Assert
        Assert.IsType<ActionResult<Vendas_Produto>>(result);
        mockRepo.Verify();
    }

    [Fact]
    public async Task Post_ReturnsAObject_WhenModelStateIsInvalid()
    {
        // Arrange
        var mockRepo = new Mock<ISaleService>();
        mockRepo.Setup(service => service.AddAsync(It.IsAny<Vendas_Produto>()))
            .Returns(Task.CompletedTask)
            .Verifiable();
        var controller = new SaleController(mockRepo.Object);
        controller.ModelState.AddModelError("SessionName", "Required");
        var newSession = new Vendas_Produto();

        // Act
        var result = await controller.Post(newSession);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.IsType<SerializableError>(badRequestResult.Value);
    }
}
