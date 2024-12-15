using Xunit;
using MyApp.Controllers;
using MyApp.Services;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class UserControllerTests
{
    private readonly Mock<UserService> _mockUserService;
    private readonly UserController _controller;

    public UserControllerTests()
    {
        _mockUserService = new Mock<UserService>();
        _controller = new UserController(_mockUserService.Object);
    }

    [Fact]
    public async Task GetAllUsers_ReturnsOkResult()
    {
        // Arrange
        _mockUserService.Setup(service => service.GetAllUsersAsync()).ReturnsAsync(new List<User>());

        // Act
        var result = await _controller.GetAllUsers();

        // Assert
        var actionResult = Assert.IsType<OkObjectResult>(result.Result);
    }
}
