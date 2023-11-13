using MvcBurger.Application.Contracts.Repositories.ExtraIngredients;
using MvcBurger.Domain.Entities;
using MvcBurger.Persistance.Contexts;
using MvcBurger.Persistance.Repositories.Common;

namespace MvcBurger.Persistance.Repositories
{
    public class ExtraIngredientRepository : EfBaseRepository<ExtraIngredient>, IExtraIngredientRepository
    {
        public ExtraIngredientRepository(BurgerDbContext context) : base(context)
        {
        }

    }
}
