using MediatR;

namespace MvcBurger.Application.Features.Commands.Drinks.Create
{
    public class CreateSauceRequest : IRequest<CreateSauceResponse>
    {
        public string Name { get; set; }
        public decimal Price { get; init; } 
    }
}

