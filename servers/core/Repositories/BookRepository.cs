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
            _ = SaveChanges();
            return result.Entity;
        }

        public Book GetById(int id)
        {
            return _context.Books.FirstOrDefault(book => book.Id == id);
        }

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book Update(Book book)
        {
            var updatedBook = _context.Books.Update(book);
            _ = SaveChanges();
            return updatedBook.Entity;
        }

        public bool Delete(Book book)
        {
            try
            {
                _context.Books.Remove(book);
                return SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool SaveChanges() => _context.SaveChanges() >= 0;
    }
}