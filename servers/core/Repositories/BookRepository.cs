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

        public bool Delete(Book book)
        {
            return _context.Books.Remove(book).IsKeySet;
        }

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book GetById(int id)
        {
            return _context.Books.FirstOrDefault(book => book.Id == id);
        }

        public Book Update(Book entity)
        {
            throw new NotImplementedException();
        }
    }
}