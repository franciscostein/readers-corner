using ReadersCorner.Core.Models;
using ReadersCorner.Core.Repositories.Interfaces;
using ReadersCorner.Core.Services.Interfaces;

namespace ReadersCorner.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _repository;

        public AuthService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> AuthenticateAsync(string login, string password)
        {
            var user = await _repository.GetUserByUsernameAsync(login);

            if (user == null || !ValidatePassword(user, password))
                return null;

            return user;
        }

        public object GenerateJwtToken(User user)
        {
            throw new NotImplementedException();
        }

        private bool ValidatePassword(User user, string password) => string.Equals(user.Password, password);
    }
}