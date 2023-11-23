using MediatR;

namespace MvcBurger.Application.Features.Commands.Drinks.Create
{
    public class DeleteOrderItemRequest : IRequest<DeleteOrderItemResponse>
    {
        public Guid OrderItemId { get; set; }

    }

}

