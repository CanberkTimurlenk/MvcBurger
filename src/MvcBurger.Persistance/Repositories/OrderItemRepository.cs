using MvcBurger.Application.Repositories;
using MvcBurger.Domain.Entities;
using MvcBurger.Persistance.Contexts;

namespace MvcBurger.Persistance.Repositories
{
    public class OrderItemRepository : EfBaseRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(BurgerDbContext context) : base(context)
        {
        }

    }
}