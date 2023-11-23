using MediatR;

namespace MvcBurger.Application.Features.Commands.Drinks.Create
{
    public class CreateOrderItemRequest : IRequest<DeleteOrderItemResponse>
    {
        public string Name { get; set; }
        public decimal Price { get; init; }
    }



}

