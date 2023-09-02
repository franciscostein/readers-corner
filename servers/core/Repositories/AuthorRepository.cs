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
            _ = SaveChanges();
            return result.Entity;
        }

        public Author GetById(int authorId)
        {
            return _context.Authors.FirstOrDefault(author => author.Id == authorId);
        }

        public List<Author> GetAll()
        {
            return _context.Authors.ToList();
        }

        public Author Update(Author author)
        {
            var result = _context.Update(author);
            _ = SaveChanges();
            return result.Entity;
        }

        public bool Delete(Author author)
        {
            try
            {
                _context.Authors.Remove(author);
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