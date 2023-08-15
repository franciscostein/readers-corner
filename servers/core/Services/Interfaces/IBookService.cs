using ReadersCorner.Core.Models;

namespace ReadersCorner.Core.Services.Interfaces
{
    public interface IBookService
    {
        Book GetBookById(int it);
        List<Book> GetAllBooks();
        Book AddBook(Book book);
        Book UpdateBook(Book book);
        void DeleteBook(int id);
    }
}