using MvcBurger.Application.DTOs.Cart;

namespace MvcBurger.Application.Features.Orders.Commands.Cart.DeleteCartItem
{
    public record DeleteCartItemResponse
    {
        public CartDto Cart { get; init; }
    }
}
