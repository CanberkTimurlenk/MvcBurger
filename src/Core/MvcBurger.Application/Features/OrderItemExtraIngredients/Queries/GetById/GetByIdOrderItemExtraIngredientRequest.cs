using MediatR;

namespace MvcBurger.Application.Features.OrderItemExtraIngredients.Queries.GetById
{
    public class GetByIdOrderItemExtraIngredientRequest : IRequest<GetByIdOrderItemExtraIngredientResponse>
    {
        public Guid Id { get; set; }

    }
}
