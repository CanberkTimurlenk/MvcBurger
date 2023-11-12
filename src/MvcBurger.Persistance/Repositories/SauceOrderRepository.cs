using MvcBurger.Application.Repositories;
using MvcBurger.Application.Repositories.MenuOrders;
using MvcBurger.Domain.Entities;
using MvcBurger.Persistance.Contexts;

namespace MvcBurger.Persistance.Repositories
{
    internal class SauceOrderRepository : EfBaseRepository<SauceOrder>, ISauceOrderRepository
    {
        public SauceOrderRepository(BurgerDbContext context) : base(context)
        {
        }

    }
}