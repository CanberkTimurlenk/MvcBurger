using MediatR;

namespace MvcBurger.Application.Features.Orders.Commands.Create
{
    public class CreateOrderRequest : IRequest<CreateOrderResponse>
    {
        public string Name { get; set; }
        public decimal Price { get; init; }
    }



}

