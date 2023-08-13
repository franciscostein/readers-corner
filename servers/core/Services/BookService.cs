using ReadersCorner.Core.Models;
using ReadersCorner.Core.Repositories.Interfaces;
using ReadersCorner.Core.Services.Interfaces;

namespace ReadersCorner.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAll();
        }

        public Book GetBookById(int bookId)
        {
            return _bookRepository.GetById(bookId);
        }

        public void UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}