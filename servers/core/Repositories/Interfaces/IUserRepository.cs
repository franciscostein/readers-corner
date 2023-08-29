using ReadersCorner.Core.Models;

namespace ReadersCorner.Core.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByUsername(string username);
    }
}