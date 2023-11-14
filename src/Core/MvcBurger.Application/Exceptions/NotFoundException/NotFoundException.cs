namespace MvcBurger.Application.Exceptions.NotFoundException
{
    public abstract class NotFoundException : Exception
    {
        public NotFoundException(string message)
            : base(message)
        {
        }
    }
}
