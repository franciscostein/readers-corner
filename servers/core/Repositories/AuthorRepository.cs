using ReadersCorner.Core.Models;
using ReadersCorner.Core.Repositories.Configurations;
using ReadersCorner.Core.Repositories.Interfaces;

namespace ReadersCorner.Core.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;

        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }

        public Author Add(Author author)
        {
            var result = _context.Authors.Add(author);
            return result.Entity;
        }

        public bool Delete(Author author)
        {
            return _context.Authors.Remove(author).IsKeySet;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Author> GetAll()
        {
            return _context.Authors.ToList();
        }

        public Author GetById(int id)
        {
            return _context.Authors.FirstOrDefault(author => author.Id == id);
        }

        public Author Update(Author entity)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges() => _context.SaveChanges() >= 0;
    }
}