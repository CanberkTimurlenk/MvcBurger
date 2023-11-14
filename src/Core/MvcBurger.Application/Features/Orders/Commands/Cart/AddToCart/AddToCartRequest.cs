using MediatR;
using MvcBurger.Application.Features.Orders.Commands.Cart.Common;

namespace MvcBurger.Application.Features.Orders.Commands.Cart.AddToCart
{
    public class AddToCartRequest : IRequest<AddToCartResponse>
    {
        public string AppUserId { get; set; }

        public IEnumerable<OrderItemRequest> OrderItemRequest { get; set; }

    }



}

