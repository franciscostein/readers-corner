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

        public Book Add(Book book)
        {
            if (book == null)
                return new Book();

            return _bookRepository.Add(book);
        }

        public bool Delete(int bookId)
        {
            return _bookRepository.Delete(bookId);
        }

        public List<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public Book GetById(int bookId)
        {
            return _bookRepository.GetById(bookId);
        }

        public Book Update(Book book)
        {
            if (book == null)
                return new Book();

            return _bookRepository.Update(book);
        }
    }
}