using ReadersCorner.Core.Models;

namespace ReadersCorner.Core.Repositories.Interfaces
{
    public interface IAuthorRepository 
    {
        Author GetAuthorById(int id);
        List<Author> GetAuthors();
        void AddAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(int id);
    }
}