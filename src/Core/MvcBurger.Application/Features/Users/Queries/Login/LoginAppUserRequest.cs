using MediatR;

namespace MvcBurger.Application.Features.Users.Queries.Login
{
    public record LoginAppUserRequest : IRequest<LoginAppUserResponse>
    {
        public string Email { get; init; }
        public string Password { get; init; }
    }
}
