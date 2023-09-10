using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
            var newUser = new User { Username = "user@test.com", Password = "#F@wv2Z$X&9@$" };
            var addedUser = new User { Id = 7, Username = newUser.Username, Password = newUser.Password };
            var mock = _mockedRepository.Create(Method.Add, newUser, addedUser);

            var result = mock.UserService.Add(newUser);

            Assert.Equal(addedUser, result);
            mock.Repository.Verify(repo => repo.Add(newUser), Times.Once());
        }

        [Fact]
        public void Add_NullUserArgument_DoesNotThrow()
        {
            var mock = _mockedRepository.Create(Method.Add, null, null);

            Assert.Null(Record.Exception(() => mock.UserService.Add(null)));
            mock.Repository.Verify(repo => repo.Add(It.IsAny<User>()), Times.Never());
        }

        [Theory]
        [InlineData(1)]
        public void Update_SuccessfulUpdate(int userId)
        {
            var userToUpdate = TestDataLoader.GetById<User>(userId);
            userToUpdate.Password = "5eY!%wwkYtPWs";
            var mock = _mockedRepository.Create(Method.Update, userId, userToUpdate, userToUpdate, userToUpdate);

            var result = mock.UserService.Update(userId, userToUpdate);

            Assert.Equal(userToUpdate, result);
            mock.Repository.Verify(repo => repo.Update(userToUpdate), Times.Once());
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Update_UserNotFound_ReturnsNull(int invalidUserId)
        {
            var mock = _mockedRepository.Create(Method.Update, invalidUserId, null, null, null);

            var result = mock.UserService.Update(invalidUserId, new User());

            Assert.Null(result);
            mock.Repository.Verify(repo => repo.Update(It.IsAny<User>()), Times.Never);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        public void Delete_SuccessfulDeletion(int userId)
        {
            var userToDelete = TestDataLoader.GetById<User>(userId);
            var mock = _mockedRepository.Create(Method.Delete, userId, userToDelete, userToDelete, true);

            var result = mock.UserService.Delete(userId);

            Assert.True(result);
            mock.Repository.Verify(repo => repo.Delete(userToDelete), Times.Once());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Delete_InvalidId_ReturnsFalse(int invalidUserId)
        {
            var mock = _mockedRepository.Create(Method.Delete, invalidUserId, null, null, false);

            var result = mock.UserService.Delete(invalidUserId);

            Assert.False(result);
            mock.Repository.Verify(repo => repo.Delete(null), Times.Never);
        }
    }
}