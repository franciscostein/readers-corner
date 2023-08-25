using ReadersCorner.Core.Models;

namespace ReadersCorner.Core.Repositories.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        bool Delete(Book book);
    }
}