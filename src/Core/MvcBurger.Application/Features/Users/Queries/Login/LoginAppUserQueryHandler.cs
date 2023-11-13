using AutoMapper;
using MediatR;
using MvcBurger.Application.Contracts.Services;

namespace MvcBurger.Application.Features.Users.Queries.Login
{
    public class LoginAppUserQueryHandler : IRequestHandler<LoginAppUserRequest, LoginAppUserResponse>
    {

        private readonly IAuthService _authService;

        public LoginAppUserQueryHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginAppUserResponse> Handle(LoginAppUserRequest request, CancellationToken cancellationToken)
        {
            var result = await _authService.LoginAsync(request.Email, request.Password);

            return new LoginAppUserResponse { UserId = result };

        }
    }
}
