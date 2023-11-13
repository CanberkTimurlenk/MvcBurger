namespace MvcBurger.Application.Exceptions.UnauthorizedException
{
    public class UserAuthenticationException : UnauthorizedAccessException
    {
        public UserAuthenticationException(string email)
            : base($"Wrong password attempt for user: {email}")
        {
        }
    }
}
