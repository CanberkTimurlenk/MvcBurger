using MvcBurger.Application.Contracts.Repositories.Menus;
using MvcBurger.Domain.Entities;
using MvcBurger.Persistance.Contexts;
using MvcBurger.Persistance.Repositories.Common;
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
