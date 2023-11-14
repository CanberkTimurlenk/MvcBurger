using MediatR;
using MvcBurger.Application.Features.Orders.Commands.Cart.Common;
using MvcBurger.Domain.Enums;

namespace MvcBurger.Application.Features.ExtraIngredients.Commands.Update
{
    public class UpdateExtraIngredientRequest : IRequest<UpdateExtraIngredientResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

    }


}

