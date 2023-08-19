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
    }
}