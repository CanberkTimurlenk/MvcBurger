using MediatR;

namespace MvcBurger.Application.Features.ExtraIngredients.Queries.GetAll
{
    public class GetAllExtraIngredientsRequest : IRequest<GetAllExtraIngredientsResponse>
    {
        public Guid Id { get; set; }

    }
}
