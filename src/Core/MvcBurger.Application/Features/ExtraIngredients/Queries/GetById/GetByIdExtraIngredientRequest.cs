using MediatR;

namespace MvcBurger.Application.Features.Queries.ExtraIngredients.GetById
{
    public class GetByIdExtraIngredientRequest : IRequest<GetByIdExtraIngredientResponse>
    {
        public Guid Id { get; set; }
    }
}
