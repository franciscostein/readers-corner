using Moq;
using ReadersCorner.Core.Models;
using ReadersCorner.Core.Repositories.Interfaces;
using ReadersCorner.Core.Services;
using Xunit;

namespace ReadersCorner.Core.Tests.Services
{
    public class AuthServiceTests
    {
        [Fact]
        public async Task AutheticateAsync_ValidCredentials_ReturnsUser()
        {
            var username = "user@email.com";
            var password = "p@s5w0rD";
            var user = new User { Id = 1, Username = username, Password = password };

            var mockRepository = new Mock<IUserRepository>();
            mockRepository.Setup(repo => repo.GetUserByUsernameAsync(username)).ReturnsAsync(user);
            var service = new AuthService(mockRepository.Object);

            var result = await service.AuthenticateAsync(username, password);

            Assert.Equal(user, result);
        }

        [Fact]
        public async void AutheticateAsync_InvalidCredentials_ReturnsNull()
        {
            var username = "user@email.com";
            var password = "wrongPassword";

            var mockRepository = new Mock<IUserRepository>();
            mockRepository.Setup(repo => repo.GetUserByUsernameAsync(username)).ReturnsAsync((User)null);
            var service = new AuthService(mockRepository.Object);

            var result = await service.AuthenticateAsync(username, password);

            Assert.Null(result);
        }
    }
}