using MediatR;

namespace MvcBurger.Application.Features.Commands.Drinks.Create
{
    public class CreateOrderItemExtraIngredientRequest : IRequest<CreateOrderItemExtraIngredientResponse>
    {
        public string Name { get; set; }
        public decimal Price { get; init; } 
    }



}

