using Xunit;
using MyApp.Services;
using MyApp.Repositories;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

public class UserServiceTests
{
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly UserService _service;

    public UserServiceTests()
    {
        _mockUserRepository = new Mock<IUserRepository>();
        _service = new UserService(_mockUserRepository.Object);
    }

    [Fact]
    public async Task GetAllUsers_ReturnsUsers()
    {
        // Arrange
        _mockUserRepository.Setup(repo => repo.GetAllUsersAsync()).ReturnsAsync(new List<User>());

        // Act
        var result = await _service.GetAllUsersAsync();

        // Assert
        Assert.IsType<List<User>>(result);
    }
}
