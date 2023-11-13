using MvcBurger.Application.Contracts.Repositories.Drinks;
using MvcBurger.Application.Contracts.Repositories.ExtraIngredients;
using MvcBurger.Application.Contracts.Repositories.Menus;
using MvcBurger.Application.Contracts.Repositories.OrderItemExtraIngredients;
using MvcBurger.Application.Contracts.Repositories.OrderItems;
using MvcBurger.Application.Contracts.Repositories.Orders;
using MvcBurger.Application.Contracts.Repositories.RepositoryManager;
using MvcBurger.Application.Contracts.Repositories.SauceOrders;
using MvcBurger.Application.Contracts.Repositories.Sauces;
using MvcBurger.Persistance.Contexts;

namespace MvcBurger.Persistance.Repositories.RepositoryManager
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly BurgerDbContext _context;
        private readonly IDrinkRepository _drinkRepository;
        private readonly IExtraIngredientRepository _extraIngredientRepository;
        private readonly IMenuRepository _menuRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ISauceOrderRepository _sauceOrderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly ISauceRepository _sauceRepository;
        private readonly IOrderItemExtraIngredientRepository _orderItemExtraIngredientRepository;

        public RepositoryManager(BurgerDbContext context, IDrinkRepository drinkRepository, IExtraIngredientRepository extraIngredientRepository,
            IMenuRepository menuRepository, IOrderRepository orderRepository, ISauceOrderRepository sauceOrderRepository,
            IOrderItemRepository orderItemRepository, ISauceRepository sauceRepository, IOrderItemExtraIngredientRepository orderItemExtraIngredientRepository)
        {
            _context = context;
            _drinkRepository = drinkRepository;
            _extraIngredientRepository = extraIngredientRepository;
            _menuRepository = menuRepository;
            _orderRepository = orderRepository;
            _sauceOrderRepository = sauceOrderRepository;
            _orderItemRepository = orderItemRepository;
            _sauceRepository = sauceRepository;
            _orderItemExtraIngredientRepository = orderItemExtraIngredientRepository;
        }

        public IDrinkRepository Drink => _drinkRepository;
        public IExtraIngredientRepository ExtraIngredient => _extraIngredientRepository;
        public IMenuRepository Menu => _menuRepository;
        public IOrderRepository Order => _orderRepository;
        public ISauceOrderRepository SauceOrder => _sauceOrderRepository;
        public IOrderItemRepository OrderItem => _orderItemRepository;
        public ISauceRepository Sauce => _sauceRepository;
        public IOrderItemExtraIngredientRepository OrderItemExtraIngredient => _orderItemExtraIngredientRepository;

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

    }
}
