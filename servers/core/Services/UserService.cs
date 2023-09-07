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

        public User Add(User user)
        {
            if (user == null)
                return null;

            return _repository.Add(user);
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

        public User Update(int userId, User user)
        {
            var existingUser = _repository.GetById(userId);
            if (existingUser == null)
            return null;

            user.Id = existingUser.Id;

            return _repository.Update(user);
        }
    }
}