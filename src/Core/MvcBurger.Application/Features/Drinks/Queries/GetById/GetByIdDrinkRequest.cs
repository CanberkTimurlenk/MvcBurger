using MediatR;

namespace MvcBurger.Application.Features.Queries.Drinks.GetById
{
    public class GetByIdDrinkRequest : IRequest<GetByIdDrinkResponse>
    {
        public Guid Id { get; set; }

    }
}
