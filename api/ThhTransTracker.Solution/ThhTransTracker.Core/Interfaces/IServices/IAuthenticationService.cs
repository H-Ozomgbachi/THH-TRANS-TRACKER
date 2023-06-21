namespace ThhTransTracker.Core.Interfaces.IServices
{
    public interface IAuthenticationService
    {
        Task<string> AuthenticateAsync(LoginDto loginDto);
    }
}