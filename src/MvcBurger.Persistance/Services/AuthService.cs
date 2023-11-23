using Microsoft.AspNetCore.Identity;
using MvcBurger.Application.Contracts.Services.UserService;
using MvcBurger.Application.Exceptions.NotFoundException;
using MvcBurger.Application.Exceptions.UnauthorizedException;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Persistance.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<AppUser> LoginAsync(string email, string password)
        {
            AppUser user = await _userManager.FindByEmailAsync(email);

            if (user is null)
                throw new UserNotFoundException(email);

            var result = await _signInManager.PasswordSignInAsync(email, password, false, false);

            if (result.Succeeded)
                return user;

            throw new UserAuthenticationException(email);
        }


        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

    }
}
