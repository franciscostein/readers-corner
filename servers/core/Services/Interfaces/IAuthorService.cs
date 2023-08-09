using ReadersCorner.Core.Models;

namespace ReadersCorner.Core.Services.Interfaces
{
    public interface IAuthorService
    {
        Author GetAuthorById(int id);
        List<Author> GetAuthors();
        void AddAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(int id);
    }
}