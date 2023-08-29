using ReadersCorner.Core.Models;
using ReadersCorner.Core.Repositories.Interfaces;

namespace ReadersCorner.Core.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<User> GetUserByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }
    }
}