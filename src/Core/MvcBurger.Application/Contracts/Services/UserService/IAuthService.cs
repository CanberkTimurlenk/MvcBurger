namespace MvcBurger.Application.Contracts.Services.UserService
{
    public interface IAuthService
    {
        Task<string> LoginAsync(string email, string password);
        Task Logout();

    }
}
