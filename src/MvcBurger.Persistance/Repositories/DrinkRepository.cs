using MvcBurger.Application.Contracts.Repositories.Drinks;
using MvcBurger.Domain.Entities;
using MvcBurger.Persistance.Contexts;
using MvcBurger.Persistance.Repositories.Common;

namespace MvcBurger.Persistance.Repositories
{
    public class DrinkRepository : EfBaseRepository<Drink>, IDrinkRepository
    {
        public DrinkRepository(BurgerDbContext context) : base(context)
        {
        }
    }
}
