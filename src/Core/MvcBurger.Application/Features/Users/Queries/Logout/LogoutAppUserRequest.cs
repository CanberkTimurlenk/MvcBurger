using MediatR;

namespace MvcBurger.Application.Features.Users.Queries.Logout
{
    public record LogoutAppUserRequest : IRequest<LogoutAppUserResponse>
    {

    }
}
