using MvcBurger.Application.Contracts.Repositories.Common;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Contracts.Repositories.Drinks
{
    public interface IDrinkRepository : IRepository<Drink>
    {
    }
}
