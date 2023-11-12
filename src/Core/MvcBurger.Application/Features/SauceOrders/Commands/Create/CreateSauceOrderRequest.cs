using MediatR;

namespace MvcBurger.Application.Features.SauceOrders.Commands.Create
{
    public class CreateSauceOrderRequest : IRequest<CreateSauceOrderResponse>
    {
        public string Name { get; set; }
        public decimal Price { get; init; }
    }
}

