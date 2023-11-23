using MvcBurger.Application.Contracts.Repositories.Drinks;
using MvcBurger.Application.Contracts.Repositories.ExtraIngredients;
using MvcBurger.Application.Contracts.Repositories.Menus;
using MvcBurger.Application.Contracts.Repositories.OrderItemExtraIngredients;
using MvcBurger.Application.Contracts.Repositories.OrderItems;
using MvcBurger.Application.Contracts.Repositories.Orders;
using MvcBurger.Application.Contracts.Repositories.SauceOrders;
using MvcBurger.Application.Contracts.Repositories.Sauces;

namespace MvcBurger.Application.Contracts.Repositories.RepositoryManager
{
    public interface IRepositoryManager
    {
        IDrinkRepository Drink { get; }
        IExtraIngredientRepository ExtraIngredient { get; }
        IMenuRepository Menu { get; }
        IOrderRepository Order { get; }
        ISauceOrderRepository SauceOrder { get; }
        IOrderItemRepository OrderItem { get; }
        ISauceRepository Sauce { get; }
        IOrderItemExtraIngredientRepository OrderItemExtraIngredient { get; }

        Task<int> SaveAsync();
    }
}
