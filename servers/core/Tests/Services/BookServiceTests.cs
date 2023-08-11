using Moq;
using ReadersCorner.Core.Models;
using ReadersCorner.Core.Repositories.Interfaces;
using ReadersCorner.Core.Services;
using Xunit;

namespace ReadersCorner.Core.Tests.Services
{
    public class BookServiceTests
    {
        [Fact]
        public void GetBookById_ValidId_ReturnCorrectBook()
        {
            int bookId = 1;
            var expectedBook = new Book
            {
                Id = bookId,
                Title = "Test Book",
                Price = 9.7m,
                Author = new Author { Id = 99, Name = "Author" }
            };

            var mockRepository = new Mock<IBookRepository>();
            mockRepository.Setup(repo => repo.GetById(bookId)).Returns(expectedBook);

            var bookService = new BookService(mockRepository.Object);

            var actualBook = bookService.GetBookById(bookId);

            Assert.Equal(expectedBook, actualBook);
        }
    }
}