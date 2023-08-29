using Moq;
using ReadersCorner.Core.Models;
using ReadersCorner.Core.Repositories.Interfaces;
using ReadersCorner.Core.Services;
using ReadersCorner.Core.Tests.Utils;
using Xunit;

namespace ReadersCorner.Core.Tests.Services
{
    public class AuthServiceTests
    {
        private readonly MockedRepositoryFactory<User> _mockedRepository;

        public AuthServiceTests()
        {
            _mockedRepository = new MockedRepositoryFactory<User>();
        }

        [Fact]
        public async Task AutheticateAsync_ValidCredentials_ReturnUser()
        {
            var username = "user@email.com";
            var password = "p@s5w0rD";
            var user = new User { Id = 1, UserName = username, Password = password };

            var mockRepository = new Mock<IUserRepository>();
            mockRepository.Setup(repo => repo.GetUserByUsername(username)).Returns(user);
            var service = new AuthService(mockRepository.Object);

            var result = await service.AuthenticateAsync(username, password);

            Assert.Equal(user, result);
        }
    }
}