using Moq;
using ReadersCorner.Core.Models;
using ReadersCorner.Core.Tests.Services.Utils;
using ReadersCorner.Core.Tests.Utils;
using Xunit;

namespace ReadersCorner.Core.Tests.Services
{
    public class AuthorServiceTests
    {
        private readonly MockedRepositoryFactory<Author> _mockedRepository;

        public AuthorServiceTests()
        {
            _mockedRepository = new MockedRepositoryFactory<Author>();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        public void GetById_ValidId_ReturnsCorrectAuthor(int authorId)
        {
            var expectedAuthor = TestDataLoader.GetSingle<Author>();
            var mock = _mockedRepository.Create(Method.GetById, authorId, expectedAuthor);

            var actualAuthor = mock.AuthorService.GetById(authorId);

            Assert.Equal(expectedAuthor, actualAuthor);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void GetById_InvalidId_ReturnsNull(int invalidAuthorId)
        {
            var mock = _mockedRepository.Create(Method.GetById, invalidAuthorId, null);

            var result = mock.AuthorService.GetById(invalidAuthorId);

            Assert.Null(result);
        }

        [Fact]
        public void GetAll_ReturnsListOfAuthors()
        {
            var expectedAuthors = TestDataLoader.GetList<Author>();
            var mock = _mockedRepository.Create(Method.GetAll, null, expectedAuthors);

            var authors = mock.AuthorService.GetAll();

            Assert.Equal(expectedAuthors, authors);
            Assert.Equal(expectedAuthors.Count, authors.Count);
        }

        [Fact]
        public void GetAll_EmptyRepository_ReturnsEmptyList()
        {
            var mock = _mockedRepository.Create(Method.GetAll, null, new List<Author>());

            var result = mock.AuthorService.GetAll();

            Assert.Empty(result);
        }

        [Fact]
        public void Add_SuccessfulAddition()
        {
            var newAuthor = new Author { Name = "Author" };
            var addedAuthor = new Author { Id = 5, Name = "Author" };
            var mock = _mockedRepository.Create(Method.Add, newAuthor, addedAuthor);

            var result = mock.AuthorService.Add(newAuthor);

            Assert.Equal(addedAuthor, result);
            mock.Repository.Verify(repo => repo.Add(newAuthor), Times.Once());
        }

        [Fact]
        public void Add_NullAuthorArgument_DoesNotThrow()
        {
            var mock = _mockedRepository.Create(Method.Add, null, null);

            Assert.Null(Record.Exception(() => mock.AuthorService.Add(null)));
            mock.Repository.Verify(repo => repo.Add(It.IsAny<Author>()), Times.Never());
        }

        [Fact]
        public void Update_SuccessfulUpdate()
        {
            var updatedAuthor = TestDataLoader.GetSingle<Author>();
            var mock = _mockedRepository.Create(Method.Update, updatedAuthor, updatedAuthor);

            var result = mock.AuthorService.Update(updatedAuthor);

            Assert.Equal(updatedAuthor, result);
            mock.Repository.Verify(repo => repo.Update(updatedAuthor), Times.Once);
        }

        [Fact]
        public void Update_NullAuthorArgument_DoesNotThrow()
        {
            var mock = _mockedRepository.Create(Method.Update, null, new Author());

            Assert.Null(Record.Exception(() => mock.AuthorService.Update(null)));
            mock.Repository.Verify(repo => repo.Update(It.IsAny<Author>()), Times.Never);
        }

        [Theory]
        [InlineData(1)]
        public void Delete_SuccessfulDeletion(int authorId)
        {
            var authorToDelete = TestDataLoader.GetById<Author>(authorId);
            var mock = _mockedRepository.Create(Method.Delete, authorId, true);

            var result = mock.AuthorService.Delete(authorId);

            Assert.True(result);
            mock.Repository.Verify(repo => repo.Delete(authorToDelete), Times.Once);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Delete_InvalidId_ReturnsFalse(int invalidId)
        {
            var mock = _mockedRepository.Create(Method.Delete, invalidId, false);

            var result = mock.AuthorService.Delete(invalidId);

            Assert.False(result);
            mock.Repository.Verify(repo => repo.Delete(null), Times.Once);
        }
    }
}