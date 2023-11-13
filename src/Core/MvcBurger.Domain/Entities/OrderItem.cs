using MvcBurger.Domain.Entities.Common;
using MvcBurger.Domain.Enums;

namespace MvcBurger.Domain.Entities
{
    public class OrderItem : BaseEntity, IEntity
    {

        public Guid MenuId { get; set; }
        public Menu Menu { get; set; }

        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public Guid DrinkId { get; set; }
        public Drink Drink { get; set; }

        public int Amount { get; set; } = 1;

        public Size Size { get; set; }

        public ICollection<OrderItemExtraIngredient> OrderItemExtraIngredient { get; set; }
    }

}
