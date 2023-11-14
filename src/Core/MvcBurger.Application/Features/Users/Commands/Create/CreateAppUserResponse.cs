namespace MvcBurger.Application.Features.Users.Commands.Create
{
    public record CreateAppUserResponse
    {
        public bool Succeeded { get; init; }
        public string Message { get; init; }
    }
}
