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
        public void GetById_ValidId_ReturnsCorrectAuthor(int authorId)
        {
            var expectedAuthor = TestDataLoader.GetSingle<Author>();
            var mock = _mockedRepository.Create(Method.GetById, authorId, expectedAuthor);

            var actualAuthor = mock.AuthorService.GetById(authorId);

            Assert.Equal(expectedAuthor, actualAuthor);
        }

        [Theory]
        [InlineData(0)]
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

            var result = mock.AuthorService.GetAll();

            Assert.Equal(expectedAuthors, result);
        }
    }
}