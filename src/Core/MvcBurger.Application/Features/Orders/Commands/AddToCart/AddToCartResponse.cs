using MvcBurger.Application.DTOs.Cart;

namespace MvcBurger.Application.Features.Orders.Commands.AddToCart
{
    public record AddToCartResponse
    {
        public CartDto Cart { get; init; }
    }
}
