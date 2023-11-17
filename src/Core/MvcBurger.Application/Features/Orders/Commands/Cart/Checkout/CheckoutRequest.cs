using MediatR;
using MvcBurger.Application.Features.Orders.Commands.Cart.Common;

namespace MvcBurger.Application.Features.Orders.Commands.Cart.Checkout
{
    public class CheckoutRequest : IRequest<CheckoutResponse>
    {
        public string AppUserId { get; set; }
    }

}

