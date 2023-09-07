using ReadersCorner.Core.Models;

namespace ReadersCorner.Core.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByUsernameAsync(string username);
    }
}