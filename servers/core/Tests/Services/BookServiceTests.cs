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
            var bookService = MockBookService(bookId, expectedBook);

            var actualBook = bookService.GetBookById(bookId);

            Assert.Equal(expectedBook, actualBook);
        }

        [Fact]
        public void GetBookById_InvalidId_ReturnsNull()
        {
            int invalidBookId = 0;
            var bookService = MockBookService<Book>(invalidBookId, null);

            var result = bookService.GetBookById(invalidBookId);

            Assert.Null(result);
        }

        [Fact]
        public void GetAllBooks_ReturnsListOfBooks()
        {
            var expectedBooks = TestDataLoader.GetList<Book>();
            var bookService = MockBookService(null, expectedBooks);

            var books = bookService.GetAllBooks();

            Assert.Equal(expectedBooks, books);
        }

        private static BookService MockBookService<T>(int? bookId, T expectedReturn)
        {
            var mockRepository = new Mock<IBookRepository>();

            switch (expectedReturn)
            {
                case Book:
                    mockRepository.Setup(repo => repo.GetById((int)bookId)).Returns(expectedReturn as Book);
                    break;
                case List<Book>:
                    mockRepository.Setup(repo => repo.GetAll()).Returns(expectedReturn as List<Book>);
                    break;
            }

            return new BookService(mockRepository.Object);
        }
    }
}