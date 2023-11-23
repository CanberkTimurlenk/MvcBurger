using MvcBurger.Application.Contracts.Repositories.SauceOrders;
using MvcBurger.Domain.Entities;
using MvcBurger.Persistance.Contexts;
using MvcBurger.Persistance.Repositories.Common;

namespace MvcBurger.Persistance.Repositories
{
    internal class SauceOrderRepository : EfBaseRepository<SauceOrder>, ISauceOrderRepository
    {
        public SauceOrderRepository(BurgerDbContext context) : base(context)
        {
        }

    }
}