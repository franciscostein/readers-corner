using ReadersCorner.Core.Models;

namespace ReadersCorner.Core.Services.Interfaces
{
    public interface IBookService
    {
        Book GetBookById(int it);
        List<Book> GetAllBooks();
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
    }
}