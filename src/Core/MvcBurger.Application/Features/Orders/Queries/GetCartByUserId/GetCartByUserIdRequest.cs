using MediatR;

namespace MvcBurger.Application.Features.Orders.Queries.GetCartByUserId
{
    public class GetCartByUserIdRequest : IRequest<GetCartByUserIdResponse>
    {
        public string AppUserId { get; set; }
    }
}
