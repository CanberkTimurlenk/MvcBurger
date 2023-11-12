using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Persistance.Configurations
{
    public class SauceOrderConfiguration : IEntityTypeConfiguration<SauceOrder>
    {
        public void Configure(EntityTypeBuilder<SauceOrder> builder)
        {
            builder
                   .HasKey(so => new { so.SauceId, so.OrderId });

            builder
                   .HasOne(so => so.Sauce)
                   .WithMany(s => s.SauceOrder)
                   .HasForeignKey(so => so.SauceId);

            builder
                   .HasOne(so => so.Order)
                   .WithMany(o => o.SauceOrder)
                   .HasForeignKey(so => so.OrderId);
        }
    }
}
