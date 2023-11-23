using MvcBurger.Application.Contracts.Repositories.OrderItemExtraIngredients;
using MvcBurger.Domain.Entities;
using MvcBurger.Persistance.Contexts;
using MvcBurger.Persistance.Repositories.Common;

namespace MvcBurger.Persistance.Repositories
{
    public class OrderItemExtraIngredientRepository : EfBaseRepository<OrderItemExtraIngredient>, IOrderItemExtraIngredientRepository
    {
        private readonly BurgerDbContext _context;
        public OrderItemExtraIngredientRepository(BurgerDbContext context) : base(context)
        {
            _context = context;
        }

        public void RemoveByOrderItemId(Guid orderItemId)
        {
            _context.OrderItemExtraIngredients.RemoveRange(_context.OrderItemExtraIngredients.Where(oei => oei.OrderItemId == orderItemId));



        }

    }
}