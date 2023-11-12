using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MvcBurger.Domain.Entities;
using System.Reflection.Emit;

namespace MvcBurger.Persistance.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder
                .HasKey(mo => new { mo.Id });

            builder
                .HasOne(mo => mo.Menu)
                .WithMany(m => m.MenuOrder)
                .HasForeignKey(mo => mo.MenuId);

            builder
                .HasOne(mo => mo.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(mo => mo.OrderId);

            builder
                .HasOne(mo => mo.Drink)
                .WithMany(d => d.MenuOrder)
                .HasForeignKey(mo => mo.DrinkId);
        }
    }
}
