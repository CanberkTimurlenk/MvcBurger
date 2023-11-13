namespace MvcBurger.Application.Contracts.Services
{
    public interface IAuthService
    {
        Task<string> LoginAsync(string email, string password);
        Task Logout();

    }
}
