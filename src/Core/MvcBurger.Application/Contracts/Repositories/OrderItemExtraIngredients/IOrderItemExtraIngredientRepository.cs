using MvcBurger.Application.Contracts.Repositories.Common;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Contracts.Repositories.OrderItemExtraIngredients
{
    public interface IOrderItemExtraIngredientRepository : IRepository<OrderItemExtraIngredient>
    {
        void RemoveByOrderItemId(Guid orderItemId);

    }
}
