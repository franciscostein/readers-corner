using ReadersCorner.Core.Models;

namespace ReadersCorner.Core.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Book GetBookById(int it);
        List<Book> GetAllBooks();
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
    }
}