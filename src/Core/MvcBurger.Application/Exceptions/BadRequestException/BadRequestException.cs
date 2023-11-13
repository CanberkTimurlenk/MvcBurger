namespace MvcBurger.Application.Exceptions.BadRequestException
{
    public abstract class BadRequestException : Exception
    {
        protected BadRequestException(string message)
            : base(message)
        {

        }
    }
}
