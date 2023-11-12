using MvcBurger.Application.Repositories;
using MvcBurger.Domain.Entities;
using MvcBurger.Persistance.Contexts;
using System.Reflection.Metadata.Ecma335;

namespace MvcBurger.Persistance.Repositories
{
    public class MenuRepository : EfBaseRepository<Menu>, IMenuRepository
    {
        public MenuRepository(BurgerDbContext context) : base(context)
        {
        }

    }
}
