using Microsoft.Extensions.DependencyInjection;
using MvcBurger.Application.Repositories.ExtraIngredientMenuOrder;
using MvcBurger.Application.Repositories.MenuOrders;
using MvcBurger.Application.Repositories;
using MvcBurger.Persistance.Contexts;
using MvcBurger.Persistance.Repositories;

namespace MvcBurger.Persistance
{
    public static class PersistenceServiceRegistration
    {

        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<BurgerDbContext>();

            services.AddScoped<IExtraIngredientRepository, ExtraIngredientRepository>();

            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IExtraIngredientRepository, ExtraIngredientRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<ISauceOrderRepository, SauceOrderRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemExtraIngredientRepository, OrderItemExtraIngredientRepository>();
            services.AddScoped<IDrinkRepository, DrinkRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<ISauceRepository, SauceRepository>();


            return services;
        }
    }
}
