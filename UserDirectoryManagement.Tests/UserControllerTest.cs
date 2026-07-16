using Microsoft.AspNetCore.Mvc;
using Moq;
using UserDirectoryManagement.Api.Controllers;
using UserDirectoryManagement.Application.DTOs;
using UserDirectoryManagement.Application.Interfaces;

namespace UserDirectoryManagement.Tests;

[TestClass]
public class UserControllerTest
{
    [TestMethod]
    public void TestMethod1()
    {
    }
    [TestMethod]
    public async Task GetUserById_ShouldReturnOk_WhenUserExists()
    {
        // Arrange
        var mockService = new Mock<IUserService>();
        mockService.Setup(s => s.GetUserByIdAsync(1))
                   .ReturnsAsync(new UserDto { Id = 1, Name = "ravi" });

        var controller = new UserController(mockService.Object);

        // Act
        var result = await controller.Get(1);

        // Assert
        var okResult = result as OkObjectResult;
        Assert.IsNotNull(okResult);
        var user = okResult.Value as UserDto;
        Assert.AreEqual("ravi", user.Name);
    }
    [TestMethod]
    public async Task GetUserById_ShouldReturnNotFound_WhenUserDoesNotExist()
    {
        var mockService = new Mock<IUserService>();
        mockService.Setup(s => s.GetUserByIdAsync(99)).ReturnsAsync((UserDto)null);

        var controller = new UserController(mockService.Object);

        var result = await controller.Get(101);

        Assert.IsInstanceOfType(result, typeof(NotFoundResult));
    }

}
