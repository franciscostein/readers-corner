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

        public Task<User> AuthenticateAsync(string login, string password)
        {
            throw new NotImplementedException();
        }

        public object GenerateJwtToken(User user)
        {
            throw new NotImplementedException();
        }
    }
}