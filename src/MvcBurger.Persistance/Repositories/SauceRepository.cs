using MvcBurger.Application.Contracts.Repositories.Sauces;
using MvcBurger.Domain.Entities;
using MvcBurger.Persistance.Contexts;
using MvcBurger.Persistance.Repositories.Common;

namespace MvcBurger.Persistance.Repositories
{
    public class SauceRepository : EfBaseRepository<Sauce>, ISauceRepository
    {
        public SauceRepository(BurgerDbContext context) : base(context)
        {

        }

    }
}
