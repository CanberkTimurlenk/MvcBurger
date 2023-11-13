namespace MvcBurger.Application.Exceptions.NotFoundException
{
    public sealed class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(string email)
            : base($"User with email: {email} was not found.")
        {
        }

        public UserNotFoundException(int id)
            : base($"User with Id: {id} was not found.")
        {
        }
    }
}
