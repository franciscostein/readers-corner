using ReadersCorner.Core.Services.Interfaces;

namespace ReadersCorner.Core.Services
{
    public class AuthService : IAuthService
    {
        public Task<bool> AuthenticateAsync(string login, string password)
        {
            throw new NotImplementedException();
        }

        public object GenerateJwtToken(bool user)
        {
            throw new NotImplementedException();
        }
    }
}