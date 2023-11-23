using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Persistance.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(moei => moei.Id);

            builder
                .HasOne(mo => mo.Menu)
                .WithMany(m => m.OrderItem)
                .HasForeignKey(mo => mo.MenuId);

            builder
                .HasOne(mo => mo.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(mo => mo.OrderId);

            builder
                .HasOne(mo => mo.Drink)
                .WithMany(d => d.OrderItem)
                .HasForeignKey(mo => mo.DrinkId);
        }
    }
}
