using MvcBurger.Domain.Entities.Common;

namespace MvcBurger.Domain.Entities
{
    public class OrderItemExtraIngredient : BaseEntity, IEntity
    {
        public Guid OrderItemId { get; set; }
        public OrderItem OrderItem { get; set; }

        public Guid ExtraIngredientId { get; set; }
        public ExtraIngredient ExtraIngredient { get; set; }

    }

}
