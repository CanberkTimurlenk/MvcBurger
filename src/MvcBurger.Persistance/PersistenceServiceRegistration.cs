using Microsoft.Extensions.DependencyInjection;
using MvcBurger.Persistance.Contexts;
using MvcBurger.Persistance.Repositories;
using MvcBurger.Application.Contracts.Repositories.Menus;
using MvcBurger.Application.Contracts.Repositories.OrderItemExtraIngredients;
using MvcBurger.Application.Contracts.Repositories.SauceOrders;
using MvcBurger.Application.Contracts.Repositories.Sauces;
using MvcBurger.Application.Contracts.Repositories.Orders;
using MvcBurger.Application.Contracts.Repositories.ExtraIngredients;
using MvcBurger.Application.Contracts.Repositories.OrderItems;
using MvcBurger.Application.Contracts.Repositories.Drinks;
using MvcBurger.Application.Contracts.Repositories.RepositoryManager;
using MvcBurger.Persistance.Repositories.RepositoryManager;
using MvcBurger.Persistance.Services;
using MvcBurger.Application.Contracts.Services.UserService;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace MvcBurger.Persistance
{
    public static class PersistenceServiceRegistration
    {

        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddDbContext<BurgerDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("SqlServerConn")));

            services.AddScoped<IRepositoryManager, RepositoryManager>();            
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IExtraIngredientRepository, ExtraIngredientRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<ISauceOrderRepository, SauceOrderRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemExtraIngredientRepository, OrderItemExtraIngredientRepository>();
            services.AddScoped<IDrinkRepository, DrinkRepository>();    
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<ISauceRepository, SauceRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
