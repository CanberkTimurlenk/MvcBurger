using MvcBurger.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MvcBurger.Persistance.Contexts
{
    public class BurgerDbContext : DbContext
    {


        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuOrder> MenuOrders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Sauce> Sauces { get; set; }
        public DbSet<SauceOrder> SauceOrders { get; set; }
        public DbSet<ExtraIngredient> ExtraIngredients { get; set; }
        public DbSet<MenuOrderExtraIngredient> MenuOrderExtraIngredient { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=127.0.0.1,11433;Database=HamburgerDb;User ID=SA;Password=Ab12345678;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuOrder>()
                .HasKey(mo => new { mo.MenuOrderId });

            modelBuilder.Entity<MenuOrder>()
                .HasOne(mo => mo.Menu)
                .WithMany(m => m.MenuOrder)
                .HasForeignKey(mo => mo.MenuId);

            modelBuilder.Entity<MenuOrder>()
                .HasOne(mo => mo.Order)
                .WithMany(o => o.MenuOrder)
                .HasForeignKey(mo => mo.OrderId);

            modelBuilder.Entity<MenuOrder>()
                .HasOne(mo => mo.Drink)
                .WithMany(d => d.MenuOrder)
                .HasForeignKey(mo => mo.DrinkId);


            modelBuilder.Entity<MenuOrderExtraIngredient>()
                .HasKey(moei => new { moei.ExtraIngredientId, moei.MenuOrderId, });

            modelBuilder.Entity<MenuOrderExtraIngredient>()
                .HasOne(moei => moei.MenuOrder)
                .WithMany(mo => mo.MenuOrderExtraIngredient)
                .HasForeignKey(moei => moei.MenuOrderId);


            modelBuilder.Entity<MenuOrderExtraIngredient>()
                .HasOne(moei => moei.ExtraIngredient)
                .WithMany(ei => ei.MenuOrderExtraIngredient)
                .HasForeignKey(moei => moei.ExtraIngredientId);


            modelBuilder.Entity<SauceOrder>()
                .HasKey(so => new { so.SauceId, so.OrderId });

            modelBuilder.Entity<SauceOrder>()
                .HasOne(so => so.Sauce)
                .WithMany(s => s.SauceOrder)
                .HasForeignKey(so => so.SauceId);

            modelBuilder.Entity<SauceOrder>()
                .HasOne(so => so.Order)
                .WithMany(o => o.SauceOrder)
                .HasForeignKey(so => so.OrderId);


        }


    }
}
