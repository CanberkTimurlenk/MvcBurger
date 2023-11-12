using MvcBurger.Application.Repositories;
using MvcBurger.Domain.Entities;
using MvcBurger.Persistance.Contexts;

namespace MvcBurger.Persistance.Repositories
{
    public class DrinkRepository : EfBaseRepository<Drink>, IDrinkRepository
    {
        public DrinkRepository(BurgerDbContext context) : base(context)
        {
        }
    }
}
