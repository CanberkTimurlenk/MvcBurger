using AutoMapper;
using MediatR;
using MvcBurger.Application.Contracts.Services.UserService;

namespace MvcBurger.Application.Features.Users.Queries.Logout
{
    public class LogoutAppUserQueryHandler : IRequestHandler<LogoutAppUserRequest, LogoutAppUserResponse>
    {

        private readonly IAuthService _authService;

        public LogoutAppUserQueryHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LogoutAppUserResponse> Handle(LogoutAppUserRequest request, CancellationToken cancellationToken)
        {
            await _authService.Logout();

            return new LogoutAppUserResponse();

        }
    }
}
