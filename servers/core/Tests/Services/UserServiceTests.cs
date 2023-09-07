using ReadersCorner.Core.Models;
using ReadersCorner.Core.Tests.Services.Utils;
using ReadersCorner.Core.Tests.Utils;
using Xunit;

namespace ReadersCorner.Core.Tests.Services
{
    public class UserServiceTests
    {
        private readonly MockedRepositoryFactory<User> _mockedRepository;

        public UserServiceTests()
        {
            _mockedRepository = new MockedRepositoryFactory<User>();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void GetById_ValidId_ReturnsCorrectUser(int userId)
        {
            var expectedUser = TestDataLoader.GetById<User>(userId);
            var mock = _mockedRepository.Create(Method.GetById, userId, expectedUser);

            var actualUser = mock.UserService.GetById(userId);

            Assert.Equal(expectedUser, actualUser);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void GetById_InvalidId_ReturnsNull(int invalidUserId)
        {
            var mock = _mockedRepository.Create(Method.GetById, invalidUserId, null);

            var result = mock.UserService.GetById(invalidUserId);

            Assert.Null(result);
        }
    }
}