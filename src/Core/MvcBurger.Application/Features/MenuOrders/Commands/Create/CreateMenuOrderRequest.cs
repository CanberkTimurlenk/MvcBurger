using MediatR;

namespace MvcBurger.Application.Features.Commands.Drinks.Create
{
    public class CreateMenuOrderRequest : IRequest<CreateMenuOrderResponse>
    {
        public string Name { get; set; }
        public decimal Price { get; init; }
    }



}

