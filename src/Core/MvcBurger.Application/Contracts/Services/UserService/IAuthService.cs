using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Contracts.Services.UserService
{
    public interface IAuthService
    {
        Task<AppUser> LoginAsync(string email, string password);
        Task Logout();        

    }
}
