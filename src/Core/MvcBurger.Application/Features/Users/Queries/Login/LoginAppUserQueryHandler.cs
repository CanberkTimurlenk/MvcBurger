using AutoMapper;
using MediatR;
using MvcBurger.Application.Contracts.Repositories.RepositoryManager;
using MvcBurger.Application.Contracts.Services.UserService;

namespace MvcBurger.Application.Features.Users.Queries.Login
{
    public class LoginAppUserQueryHandler : IRequestHandler<LoginAppUserRequest, LoginAppUserResponse>
    {

        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public LoginAppUserQueryHandler(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        public async Task<LoginAppUserResponse> Handle(LoginAppUserRequest request, CancellationToken cancellationToken)
        {
            var result = await _authService.LoginAsync(request.Email, request.Password);

            

            var roles = await _userService.GetRolesByUserAsync(result);

            return new LoginAppUserResponse { UserId = result.Id, Roles = roles };

        }
    }
}
