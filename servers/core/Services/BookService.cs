using ReadersCorner.Core.Models;
using ReadersCorner.Core.Repositories.Interfaces;
using ReadersCorner.Core.Services.Interfaces;

namespace ReadersCorner.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public Book Add(Book book)
        {
            if (book == null)
                return new Book();

            return _repository.Add(book);
        }

        public bool Delete(int bookId)
        {
            var bookToDelete = _repository.GetById(bookId);
            if (bookToDelete == null)
                return false;

            return _repository.Delete(bookToDelete);
        }

        public List<Book> GetAll()
        {
            return _repository.GetAll();
        }

        public Book GetById(int bookId)
        {
            return _repository.GetById(bookId);
        }

        public Book Update(int bookId, Book book)
        {
            var existingBook = _repository.GetById(bookId);
            if (existingBook == null)
                return null;

            book.Id = existingBook.Id;

            return _repository.Update(book);
        }
    }
}