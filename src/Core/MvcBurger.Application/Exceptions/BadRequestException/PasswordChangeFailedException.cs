namespace MvcBurger.Application.Exceptions.BadRequestException
{
    public sealed class PasswordChangeFailedException : BadRequestException
    {
        public PasswordChangeFailedException()
            : base("An error occured when updating the password.")
        {
        }
    }
}
