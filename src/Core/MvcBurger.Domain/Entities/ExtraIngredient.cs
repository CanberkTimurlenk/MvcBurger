using MvcBurger.Domain.Entities.Common;

namespace MvcBurger.Domain.Entities
{
    public class ExtraIngredient : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public ICollection<MenuOrderExtraIngredient> MenuOrderExtraIngredient { get; set; }

    }

}
