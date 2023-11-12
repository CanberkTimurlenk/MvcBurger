using MvcBurger.Application.Repositories;
using MvcBurger.Domain.Entities;
using MvcBurger.Persistance.Contexts;

namespace MvcBurger.Persistance.Repositories
{
    public class SauceRepository : EfBaseRepository<Sauce>, ISauceRepository
    {
        public SauceRepository(BurgerDbContext context) : base(context)
        {

        }

    }
}
