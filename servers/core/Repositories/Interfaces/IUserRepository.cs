using ReadersCorner.Core.Models;

namespace ReadersCorner.Core.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsernameAsync(string username);
    }
}