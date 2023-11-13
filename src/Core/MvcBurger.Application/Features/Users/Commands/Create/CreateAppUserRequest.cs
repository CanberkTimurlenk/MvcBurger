using MediatR;

namespace ConsoleApplication.NewFolder
{
    public record CreateAppUserRequest : IRequest<CreateAppUserResponse>
    {
        public string Firstname { get; init; }
        public string Lastname { get; init; }
        public string Address { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
    }
}

