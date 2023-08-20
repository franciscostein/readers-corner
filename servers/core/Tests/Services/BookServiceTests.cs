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
        public void UpdateBook_SuccessfulUpdate()
        {
            var updatedBook = TestDataLoader.GetSingle<Book>();
            var mock = _mockedRepository.Create(Method.Update, updatedBook, updatedBook);

            var result = mock.BookService.Update(updatedBook);

            Assert.Equal(updatedBook, result);
            mock.Repository.Verify(repo => repo.Update(updatedBook), Times.Once);
        }

        [Fact]
        public void UpdateBook_NullBookArgument_DoesNotThrow()
        {
            var mock = _mockedRepository.Create(Method.Update, null, new Book());

            Assert.Null(Record.Exception(() => mock.BookService.Update(null)));
            mock.Repository.Verify(repo => repo.Update(It.IsAny<Book>()), Times.Never);
        }

        [Fact]
        public void DeleteBook_SuccessfulDeletion()
        {
            var bookIdToDelete = 1;
            var mock = _mockedRepository.Create(Method.Delete, bookIdToDelete, true);

            var result = mock.BookService.Delete(bookIdToDelete);

            Assert.True(result);
            mock.Repository.Verify(repo => repo.Delete(bookIdToDelete), Times.Once);
        }

        [Fact]
        public void DeleteBook_InvalidId_ReturnsFalse()
        {
            var invalidBookId = -1;
            var mock = _mockedRepository.Create(Method.Delete, invalidBookId, false);

            var result = mock.BookService.Delete(invalidBookId);

            Assert.False(result);
            mock.Repository.Verify(repo => repo.Delete(invalidBookId), Times.Once);
        }
    }
}