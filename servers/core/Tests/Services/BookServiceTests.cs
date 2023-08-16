using Moq;
using ReadersCorner.Core.Models;
using ReadersCorner.Core.Repositories.Interfaces;
using ReadersCorner.Core.Services;
using ReadersCorner.Core.Tests.Services.Utils;
using Xunit;

namespace ReadersCorner.Core.Tests.Services
{
    public class BookServiceTests
    {
        [Fact]
        public void GetBookById_ValidId_ReturnCorrectBook()
        {
            int bookId = 1;
            var expectedBook = TestDataLoader.GetSingle<Book>();
            var mock = MockRepository(Method.GetById, bookId, expectedBook);

            var actualBook = mock.BookService.GetBookById(bookId);

            Assert.Equal(expectedBook, actualBook);
        }

        [Fact]
        public void GetBookById_InvalidId_ReturnsNull()
        {
            int invalidBookId = 0;
            var mock = MockRepository<Book>(Method.GetById, invalidBookId, null);

            var result = mock.BookService.GetBookById(invalidBookId);

            Assert.Null(result);
        }

        [Fact]
        public void GetAllBooks_ReturnsListOfBooks()
        {
            var expectedBooks = TestDataLoader.GetList<Book>();
            var mock = MockRepository(Method.GetAll, null, expectedBooks);

            var books = mock.BookService.GetAllBooks();

            Assert.Equal(expectedBooks, books);
        }

        [Fact]
        public void GetAllBooks_EmptyRepository_ReturnsEmptyList()
        {
            var mock = MockRepository(Method.GetAll, null, new List<Book>());

            var result = mock.BookService.GetAllBooks();

            Assert.Empty(result);
        }

        [Fact]
        public void AddBook_SuccessfulAddition()
        {
            var newBook = new Book { Title = "New Book" };
            var addedBook = new Book { Id = 5, Title = "New Book" };
            var mock = MockRepository<Book>(Method.Add, newBook, addedBook);

            var result = mock.BookService.AddBook(newBook);

            Assert.Equal(addedBook, result);
            mock.Repository.Verify(repo => repo.Add(newBook), Times.Once);
        }

        [Fact]
        public void AddBook_NullBookArgument_DoesNotThrow()
        {
            var mock = MockRepository<Book>(Method.Add, null, null);

            Assert.Null(Record.Exception(() => mock.BookService.AddBook(null)));
            mock.Repository.Verify(repo => repo.Add(It.IsAny<Book>()), Times.Never);
        }

        [Fact]
        public void UpdateBook_SuccessfulUpdate()
        {
            var updatedBook = TestDataLoader.GetSingle<Book>();
            var mock = MockRepository<Book>(Method.Add, updatedBook, updatedBook);

            var result = mock.BookService.UpdateBook(updatedBook);

            Assert.Equal(updatedBook, result);
            mock.Repository.Verify(repo => repo.Update(updatedBook), Times.Once);
        }

        [Fact]
        public void UpdateBook_NullBookArgument_DoesNotThrow()
        {
            var mock = MockRepository<Book>(Method.Update, null, null);

            Assert.Null(Record.Exception(() => mock.BookService.UpdateBook(null)));
            mock.Repository.Verify(repo => repo.Update(It.IsAny<Book>()), Times.Never);
        }

        private static MockedRepository MockRepository<T>(Method method, object input, T expectedReturn)
        {
            var mockRepository = new Mock<IBookRepository>();

            switch (method)
            {
                case Method.GetById:
                    mockRepository.Setup(repo => repo.GetById((int)input)).Returns(expectedReturn as Book);
                    break;
                case Method.GetAll:
                    mockRepository.Setup(repo => repo.GetAll()).Returns(expectedReturn as List<Book>);
                    break;
                case Method.Add:
                    mockRepository.Setup(repo => repo.Add((Book)input)).Returns(expectedReturn as Book);
                    break;
                case Method.Update:
                    mockRepository.Setup(repo => repo.Update((Book)input)).Returns(expectedReturn as Book);
                    break;
            }

            var bookService = new BookService(mockRepository.Object);

            return new MockedRepository(mockRepository, bookService);
        }

        private class MockedRepository
        {
            public MockedRepository(Mock<IBookRepository> mockRepository, BookService bookService)
            {
                Repository = mockRepository;
                BookService = bookService;
            }

            public Mock<IBookRepository> Repository { get; }
            public BookService BookService { get; }
        }

        enum Method
        {
            GetById,
            GetAll,
            Add,
            Update,
            Delete
        }
    }
}