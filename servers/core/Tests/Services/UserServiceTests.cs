using Moq;
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

        [Fact]
        public void GetAll_ReturnsUsersList()
        {
            var expectedUsers = TestDataLoader.GetList<User>();
            var mock = _mockedRepository.Create(Method.GetAll, null, expectedUsers);

            var users = mock.UserService.GetAll();

            Assert.Equal(expectedUsers, users);
            Assert.Equal(expectedUsers.Count, users.Count);
        }

        [Fact]
        public void GetAll_EmptyRepository_ReturnsEmptyList()
        {
            var mock = _mockedRepository.Create(Method.GetAll, null, new List<User>());

            var result = mock.UserService.GetAll();

            Assert.Empty(result);
        }

        [Fact]
        public void Add_SuccessfulAddition()
        {
            var newUser = new User { UserName = "user@test.com", Password = "#F@wv2Z$X&9@$" };
            var addedUser = newUser;
            addedUser.Id = 4;

            var mock = _mockedRepository.Create(Method.Add, newUser, addedUser);

            var result = mock.UserService.Add(newUser);

            Assert.Equal(addedUser, result);
            mock.Repository.Verify(repo => repo.Add(newUser), Times.Once());
        }
    }
}