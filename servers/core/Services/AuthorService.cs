using ReadersCorner.Core.Models;
using ReadersCorner.Core.Repositories.Interfaces;
using ReadersCorner.Core.Services.Interfaces;

namespace ReadersCorner.Core.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;

        public AuthorService(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public Author Add(Author author)
        {
            if (author == null)
                return new Author();

            return _repository.Add(author);
        }

        public bool Delete(int authorId)
        {
            var authorToDelete = _repository.GetById(authorId);
            if (authorToDelete == null)
                throw new ArgumentException("Invalid ID");

            return _repository.Delete(authorToDelete);
        }

        public List<Author> GetAll()
        {
            return _repository.GetAll();
        }

        public Author GetById(int authorId)
        {
            return _repository.GetById(authorId);
        }

        public Author Update(Author author)
        {
            if (author == null)
                return new Author();

            return _repository.Update(author);
        }
    }
}