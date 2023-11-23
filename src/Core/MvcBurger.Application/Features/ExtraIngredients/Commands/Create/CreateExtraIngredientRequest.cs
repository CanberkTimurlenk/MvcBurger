using MediatR;

namespace MvcBurger.Application.Features.Commands.Drinks.Create
{
    public class CreateExtraIngredientRequest : IRequest<CreateExtraIngredientResponse>
    {
        public string Name { get; set; }
        public decimal Price { get; init; } 
    }



}

