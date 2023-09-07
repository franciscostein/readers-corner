using ReadersCorner.Core.Models;
using ReadersCorner.Core.Repositories.Interfaces;
using ReadersCorner.Core.Services.Interfaces;

namespace ReadersCorner.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public User Add(User model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            return _repository.GetAll();
        }

        public User GetById(int userId)
        {
            return _repository.GetById(userId);
        }

        public User Update(int userId, User model)
        {
            throw new NotImplementedException();
        }
    }
}