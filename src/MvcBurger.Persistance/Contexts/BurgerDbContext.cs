using MvcBurger.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MvcBurger.Persistance.Contexts
{
    public class BurgerDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Menu> Menus { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Sauce> Sauces { get; set; }
        public DbSet<SauceOrder> SauceOrders { get; set; }
        public DbSet<ExtraIngredient> ExtraIngredients { get; set; }
        public DbSet<OrderItemExtraIngredient> MenuOrderExtraIngredient { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=127.0.0.1,11433;Database=HamburgerDb;User ID=SA;Password=Ab12345678;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BurgerDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
