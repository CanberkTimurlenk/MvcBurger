using MvcBurger.Application.DTOs.Cart;

namespace MvcBurger.Application.Features.Orders.Commands.Cart.AddToCart
{
    public record AddToCartResponse
    {
        public CartDto Cart { get; init; }
    }
}
