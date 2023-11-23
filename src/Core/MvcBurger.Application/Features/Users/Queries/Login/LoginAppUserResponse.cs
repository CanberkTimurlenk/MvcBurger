namespace MvcBurger.Application.Features.Users.Queries.Login
{
    public record LoginAppUserResponse
    {
        public string UserId { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
