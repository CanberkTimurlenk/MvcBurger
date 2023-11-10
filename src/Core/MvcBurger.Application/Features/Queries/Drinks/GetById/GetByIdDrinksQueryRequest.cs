using MediatR;

namespace MvcBurger.Application.Features.Queries.Drinks.GetById
{
    public class GetByIdDrinksQueryRequest : IRequest<GetByIdDrinksQueryResponse>
    {
        public Guid Id { get; set; }

    }
}
