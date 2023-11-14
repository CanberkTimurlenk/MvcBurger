namespace MvcBurger.Application.Exceptions.BadRequestException
{
    public sealed class PasswordChangeFailedException : BadRequestException , ICustomException
    {
        public PasswordChangeFailedException()
            : base("An error occured when updating the password.")
        {
        }
    }
}
