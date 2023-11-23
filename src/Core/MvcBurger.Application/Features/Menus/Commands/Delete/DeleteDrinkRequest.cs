using MediatR;
using MvcBurger.Application.Features.Orders.Commands.Cart.UpdateCartItem;

namespace MvcBurger.Application.Features.Menus.Commands.Delete
{
    public class DeleteMenuRequest : IRequest<DeleteMenuResponse>
    {
        public Guid MenuId { get; set; }

    }
}

