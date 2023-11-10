using MvcBurger.Domain.Entities.Common;

namespace MvcBurger.Domain.Entities
{
    public class MenuOrder : IEntity
    {
        public Guid MenuOrderId { get; set; }
        public Guid MenuId { get; set; }
        public Menu Menu { get; set; }

        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public Guid DrinkId { get; set; }
        public Drink Drink { get; set; }

        public ICollection<MenuOrderExtraIngredient> MenuOrderExtraIngredient { get; set; }
    }

}
