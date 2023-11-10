using MediatR;

namespace MvcBurger.Application.Features.Queries.Drinks.GetAllDrinks
{
    public class GetAllDrinksQueryRequest : IRequest<IEnumerable<GetAllDrinksQueryResponse>>
    {

    }
}
