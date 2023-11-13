namespace MvcBurger.Application.Contracts.Services
{
    public interface IAuthService
    {
        public Task<bool> LoginAsync(string email, string password);

    }
}
