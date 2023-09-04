using Moq;
using ReadersCorner.Core.Models;
using ReadersCorner.Core.Tests.Services.Utils;
using ReadersCorner.Core.Tests.Utils;
using Xunit;

namespace ReadersCorner.Core.Tests.Services
{
    public class BookServiceTests
    {
        private readonly MockedRepositoryFactory<Book> _mockedRepository;

        public BookServiceTests()
        {
            _mockedRepository = new MockedRepositoryFactory<Book>();
        }

        [Fact]
        public void GetById_ValidId_ReturnCorrectBook()
        {
            int bookId = 1;
            var expectedBook = TestDataLoader.GetSingle<Book>();
            var mock = _mockedRepository.Create(Method.GetById, bookId, expectedBook);

            var actualBook = mock.BookService.GetById(bookId);

            Assert.Equal(expectedBook, actualBook);
        }

        [Fact]
        public void GetById_InvalidId_ReturnsNull()
        {
            int invalidBookId = 0;
            var mock = _mockedRepository.Create(Method.GetById, invalidBookId, null);

            var result = mock.BookService.GetById(invalidBookId);

            Assert.Null(result);
        }

        [Fact]
        public void GetAll_ReturnsListOfBooks()
        {
            var expectedBooks = TestDataLoader.GetList<Book>();
            var mock = _mockedRepository.Create(Method.GetAll, null, expectedBooks);

            var books = mock.BookService.GetAll();

            Assert.Equal(expectedBooks, books);
            Assert.Equal(expectedBooks, books);
        }

        [Fact]
        public void GetAll_EmptyRepository_ReturnsEmptyList()
        {
            var mock = _mockedRepository.Create(Method.GetAll, null, new List<Book>());

            var result = mock.BookService.GetAll();

            Assert.Empty(result);
        }

        [Fact]
        public void Add_SuccessfulAddition()
        {
            var newBook = new Book { Title = "New Book" };
            var addedBook = new Book { Id = 5, Title = "New Book" };
            var mock = _mockedRepository.Create(Method.Add, newBook, addedBook);

            var result = mock.BookService.Add(newBook);

            Assert.Equal(addedBook, result);
            mock.Repository.Verify(repo => repo.Add(newBook), Times.Once);
        }

        [Fact]
        public void Add_NullBookArgument_DoesNotThrow()
        {
            var mock = _mockedRepository.Create(Method.Add, null, null);

            Assert.Null(Record.Exception(() => mock.BookService.Add(null)));
            mock.Repository.Verify(repo => repo.Add(It.IsAny<Book>()), Times.Never);
        }

        [Fact]
        public void Update_SuccessfulUpdate()
        {
            var bookId = 1;
            var updatedBook = TestDataLoader.GetSingle<Book>();
            var mock = _mockedRepository.Create(Method.Update, updatedBook, updatedBook);

            var result = mock.BookService.Update(bookId, updatedBook);

            Assert.Equal(updatedBook, result);
            mock.Repository.Verify(repo => repo.Update(updatedBook), Times.Once);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Update_InvalidId_ReturnsNull(int invalidId)
        {
            var bookToUpdate = TestDataLoader.GetSingle<Book>();
            var mock = _mockedRepository.Create(Method.Update, null, new Book());

            var result = mock.BookService.Update(invalidId, bookToUpdate);

            Assert.Null(result);
            mock.Repository.Verify(repo => repo.Update(It.IsAny<Book>()), Times.Never);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        public void Delete_SuccessfulDeletion(int bookId)
        {
            var bookToDelete = TestDataLoader.GetById<Book>(bookId);
            var mock = _mockedRepository.Create(Method.Delete, bookId, bookToDelete, bookToDelete, true);

            var result = mock.BookService.Delete(bookId);

            Assert.True(result);
            mock.Repository.Verify(repo => repo.Delete(bookToDelete), Times.Once);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Delete_InvalidId_ReturnsFalse(int invalidBookId)
        {
            var mock = _mockedRepository.Create(Method.Delete, invalidBookId, null, null, false);

            var result = mock.BookService.Delete(invalidBookId);

            Assert.False(result);
            mock.Repository.Verify(repo => repo.Delete(null), Times.Never);
        }
    }
}