using ReadersCorner.Core.Models;
using ReadersCorner.Core.Repositories.Configurations;
using ReadersCorner.Core.Repositories.Interfaces;

namespace ReadersCorner.Core.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public Book Add(Book book)
        {
            var result = _context.Books.Add(book);
            return result.Entity;
        }

        public void Delete(Book book)
        {
            _context.Books.Remove(book);
        }

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book GetById(int id)
        {
            return _context.Books.FirstOrDefault(book => book.Id == id);
        }

        public Book Update(Book book)
        {
            var updatedBook = _context.Books.Update(book);
            return updatedBook.Entity;
        }

        public bool SaveChanges() => _context.SaveChanges() >= 0;
    }
}