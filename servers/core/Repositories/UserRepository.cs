using ReadersCorner.Core.Models;
using ReadersCorner.Core.Repositories.Interfaces;

namespace ReadersCorner.Core.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User Add(User model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(User model)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }

        public User Update(User model)
        {
            throw new NotImplementedException();
        }
    }
}