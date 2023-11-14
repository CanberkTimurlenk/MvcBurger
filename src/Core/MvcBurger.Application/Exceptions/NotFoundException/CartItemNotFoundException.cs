namespace MvcBurger.Application.Exceptions.NotFoundException
{
    public sealed class CartItemNotFoundException : NotFoundException, ICustomException
    {
        public CartItemNotFoundException(string userId, Guid cartItemId) :
            base($"UserId: {userId} does not have such a cart item {cartItemId}")
        { }

    }
}
