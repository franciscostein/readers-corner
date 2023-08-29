namespace ReadersCorner.Core.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> AuthenticateAsync(string login, string password);
        object GenerateJwtToken(bool user);
    }
}