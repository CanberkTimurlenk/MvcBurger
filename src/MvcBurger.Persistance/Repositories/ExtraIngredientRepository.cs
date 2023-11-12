using MvcBurger.Application.Repositories;
using MvcBurger.Domain.Entities;
using MvcBurger.Persistance.Contexts;

namespace MvcBurger.Persistance.Repositories
{
    public class ExtraIngredientRepository : EfBaseRepository<ExtraIngredient>, IExtraIngredientRepository
    {
        public ExtraIngredientRepository(BurgerDbContext context) : base(context)
        {
        }

    }
}
