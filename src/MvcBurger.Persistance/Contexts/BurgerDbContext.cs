using MvcBurger.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MvcBurger.Persistance.Contexts
{
    public class BurgerDbContext : IdentityDbContext<AppUser>
    {
        public BurgerDbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Sauce> Sauces { get; set; }
        public DbSet<SauceOrder> SauceOrders { get; set; }
        public DbSet<ExtraIngredient> ExtraIngredients { get; set; }
        public DbSet<OrderItemExtraIngredient> OrderItemExtraIngredients { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BurgerDbContext).Assembly);
        }
    }
}
