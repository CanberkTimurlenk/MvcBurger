using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Persistance.Configurations
{
    public class MenuOrderExtraIngredientConfiguration : IEntityTypeConfiguration<MenuOrderExtraIngredient>
    {
        public void Configure(EntityTypeBuilder<MenuOrderExtraIngredient> builder)
        {
            builder
                .HasKey(moei => new { moei.ExtraIngredientId, moei.MenuOrderId });

            builder
                .HasOne(moei => moei.MenuOrder)
                .WithMany(mo => mo.MenuOrderExtraIngredient)
                .HasForeignKey(moei => moei.MenuOrderId);


            builder
                .HasOne(moei => moei.ExtraIngredient)
                .WithMany(ei => ei.MenuOrderExtraIngredient)
                .HasForeignKey(moei => moei.ExtraIngredientId);
        }
    }
}
