using ReadersCorner.Core.Models;

namespace ReadersCorner.Core.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User> AuthenticateAsync(string login, string password);
        object GenerateJwtToken(User user);
    }
}