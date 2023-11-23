using MediatR;
using MvcBurger.Application.Features.Orders.Commands.Cart.Common;
using MvcBurger.Domain.Enums;

namespace MvcBurger.Application.Features.Orders.Commands.Cart.UpdateCartItem
{
    public class DeleteExtraIngredientRequest : IRequest<DeleteExtraIngredientResponse>
    {
        public Guid ExtraIngredientId { get; set; }

    }
}

