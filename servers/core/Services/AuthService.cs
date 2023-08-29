using ReadersCorner.Core.Models;
using ReadersCorner.Core.Services.Interfaces;

namespace ReadersCorner.Core.Services
{
    public class AuthService : IAuthService
    {
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