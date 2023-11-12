using MvcBurger.Application.Repositories.ExtraIngredientMenuOrder;
using MvcBurger.Application.Repositories.MenuOrders;
using MvcBurger.Domain.Entities;
using MvcBurger.Persistance.Contexts;

namespace MvcBurger.Persistance.Repositories
{
    public class OrderRepository : EfBaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(BurgerDbContext context) : base(context)
        {
        }

    }
}
