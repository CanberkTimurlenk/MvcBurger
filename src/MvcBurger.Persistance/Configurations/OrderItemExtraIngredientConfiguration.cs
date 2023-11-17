using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Persistance.Configurations
{
    public class OrderItemExtraIngredientConfiguration : IEntityTypeConfiguration<OrderItemExtraIngredient>
    {
        public void Configure(EntityTypeBuilder<OrderItemExtraIngredient> builder)
        {
            builder.HasKey(moei => moei.Id);

            builder
                .HasOne(moei => moei.OrderItem)
                .WithMany(mo => mo.OrderItemExtraIngredient)
                .HasForeignKey(moei => moei.OrderItemId);


            builder
                .HasOne(moei => moei.ExtraIngredient)
                .WithMany(ei => ei.OrderItemExtraIngredient)
                .HasForeignKey(moei => moei.ExtraIngredientId);
        }
    }
}
