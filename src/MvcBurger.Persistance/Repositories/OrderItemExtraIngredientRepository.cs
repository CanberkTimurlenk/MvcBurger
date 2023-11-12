using MvcBurger.Application.Repositories;
using MvcBurger.Application.Repositories.ExtraIngredientMenuOrder;
using MvcBurger.Domain.Entities;
using MvcBurger.Persistance.Contexts;

namespace MvcBurger.Persistance.Repositories
{
    public class OrderItemExtraIngredientRepository : EfBaseRepository<OrderItemExtraIngredient>, IOrderItemExtraIngredientRepository
    {
        public OrderItemExtraIngredientRepository(BurgerDbContext context) : base(context)
        {
        }

    }
}