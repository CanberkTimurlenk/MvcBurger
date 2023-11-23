using MvcBurger.Application.DTOs.Cart;

namespace MvcBurger.Application.Features.ExtraIngredients.Commands.Update
{
    public record UpdateExtraIngredientResponse
    {
        public CartDto Cart { get; init; }
    }
}
