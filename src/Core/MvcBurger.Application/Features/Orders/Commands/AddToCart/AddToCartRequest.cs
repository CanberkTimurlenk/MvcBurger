using MediatR;
using MvcBurger.Domain.Enums;

namespace MvcBurger.Application.Features.Orders.Commands.AddToCart
{
    public class AddToCartRequest : IRequest<AddToCartResponse>
    {
        public string AppUserId { get; set; }

        public IEnumerable<OrderItemRequest> OrderItemRequest { get; set; }

    }

    public class OrderItemRequest
    {
        public Guid MenuId { get; set; }
        public Guid DrinkId { get; set; }
        public int Amount { get; set; }
        public Size Size { get; set; }


    }



}

