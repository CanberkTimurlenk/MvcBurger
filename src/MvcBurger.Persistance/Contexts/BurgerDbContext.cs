using MvcBurger.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MvcBurger.Persistance.Contexts
{
    public class BurgerDbContext : IdentityDbContext<AppUser>
    {

        public DbSet<Menu> Menus { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Sauce> Sauces { get; set; }
        public DbSet<SauceOrder> SauceOrders { get; set; }
        public DbSet<ExtraIngredient> ExtraIngredients { get; set; }
        public DbSet<OrderItemExtraIngredient> OrderItemExtraIngredients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-6262GND\\SQLEXPRESS;Initial Catalog=MVCHamburgerDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BurgerDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
