using MediatR;

namespace MvcBurger.Application.Features.OrderItems.Queries.GetById
{
    public class GetByIdOrderItemRequest : IRequest<GetByIdOrderItemResponse>
    {
        public Guid Id { get; set; }

    }
}
