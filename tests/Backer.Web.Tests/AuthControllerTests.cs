using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Backer.Application.Features.Users.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using Backer.Utilities;
using Backer.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace Backer.Web.Tests;

public class AuthControllerTests
{
    private readonly Mock<ITokenService> _tokenServiceMock = new();
    private readonly Mock<IRepository<User>> _userRepositoryMock = new();
    private readonly IConfiguration _configuration = new ConfigurationBuilder()
        .AddInMemoryCollection(new Dictionary<string, string>
        {
            ["Jwt:TokenValidityInMinutes"] = "60",
        })
        .Build();

    [Fact]
    public async Task Login_ReturnsToken_WhenCredentialsAreValid()
    {
        // Arrange
        var request = new LoginRequestModel("username", "password");
        var storedUser = CreateUser("username", "hashed");

        _userRepositoryMock
            .Setup(repo => repo.FindAsync(
                It.IsAny<Expression<Func<User, bool>>>(),
                It.IsAny<Expression<Func<User, object>>[]>()))
            .ReturnsAsync(new[] { storedUser });

        _tokenServiceMock
            .Setup(service => service.VerifyPassword(request.Password, storedUser.Password))
            .Returns(true);

        _tokenServiceMock
            .Setup(service => service.GenerateToken(storedUser.Username))
            .Returns("generated-token");

        using var cache = new MemoryCache(new MemoryCacheOptions());
        var controller = CreateController(cache);

        // Act
        var result = await controller.Login(request);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);

        var successProperty = okResult.Value!.GetType().GetProperty("success");
        Assert.NotNull(successProperty);
        Assert.True((bool)successProperty!.GetValue(okResult.Value)!);

        var tokenProperty = okResult.Value.GetType().GetProperty("token");
        Assert.Equal("generated-token", tokenProperty?.GetValue(okResult.Value));

        _tokenServiceMock.Verify(service => service.VerifyPassword(request.Password, storedUser.Password), Times.Once);
        _tokenServiceMock.Verify(service => service.GenerateToken(storedUser.Username), Times.Once);
    }

    [Fact]
    public async Task Login_ReturnsFailedResponse_WhenPasswordIsInvalid()
    {
        // Arrange
        var request = new LoginRequestModel("username", "wrong-password");
        var storedUser = CreateUser("username", "hashed");

        _userRepositoryMock
            .Setup(repo => repo.FindAsync(
                It.IsAny<Expression<Func<User, bool>>>(),
                It.IsAny<Expression<Func<User, object>>[]>()))
            .ReturnsAsync(new[] { storedUser });

        _tokenServiceMock
            .Setup(service => service.VerifyPassword(request.Password, storedUser.Password))
            .Returns(false);

        using var cache = new MemoryCache(new MemoryCacheOptions());
        var controller = CreateController(cache);

        // Act
        var result = await controller.Login(request);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<Respone>(okResult.Value);

        Assert.Equal(ResponseState.Failed, response.State);
        Assert.Equal("رمز عبور وارد شده نامعتبر می باشد", response.Data);

        _tokenServiceMock.Verify(service => service.VerifyPassword(request.Password, storedUser.Password), Times.Once);
        _tokenServiceMock.Verify(service => service.GenerateToken(It.IsAny<string>()), Times.Never);
    }

    private AuthController CreateController(IMemoryCache cache)
    {
        return new AuthController(_tokenServiceMock.Object, _userRepositoryMock.Object, cache, _configuration);
    }

    private static User CreateUser(string username, string password)
    {
        return new User
        {
            Username = username,
            Password = password,
            BeginDate = DateTime.UtcNow,
            JobId = 1,
            Fullname = "Full Name"
        };
    }
}
