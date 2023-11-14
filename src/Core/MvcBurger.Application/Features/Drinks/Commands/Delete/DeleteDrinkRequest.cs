using MediatR;
using MvcBurger.Application.Features.Orders.Commands.Cart.UpdateCartItem;

namespace MvcBurger.Application.Features.Drinks.Commands.Delete
{
    public class DeleteDrinkRequest : IRequest<DeleteDrinkResponse>
    {
        public Guid ExtraIngredientId { get; set; }

    }
}

