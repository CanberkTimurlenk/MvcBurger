using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Persistance.Configurations
{
    public class DrinkConfiguration : IEntityTypeConfiguration<Drink>
    {
        public void Configure(EntityTypeBuilder<Drink> builder)
        {
            builder.HasData(
                new Drink { Id = new Guid("4d9b2a79-8eb2-4162-a636-fc6b60301c09"), Name = "Fanta" },
                new Drink { Id = new Guid("b6ed9936-b985-4f92-9e36-1789916b6ffd"), Name = "Cola" },
                new Drink { Id = new Guid("7c7802de-55b9-4cd0-977f-331e730006ee"), Name = "Sprite" },
                new Drink { Id = new Guid("c094082d-7245-44f0-9638-fd7a82d432ac"), Name = "Ice-Tea" },
                new Drink { Id = new Guid("5f7ea456-b664-4f64-a579-bd0d6ce1f965"), Name = "Dr Pepper" }
                );
        }
    }
}
