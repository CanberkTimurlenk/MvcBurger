using MvcBurger.Domain.Entities.Common;

namespace MvcBurger.Domain.Entities
{
    public class OrderItemExtraIngredient : IEntity
    {
        public Guid MenuOrderId { get; set; }
        public OrderItem MenuOrder { get; set; }

        public Guid ExtraIngredientId { get; set; }
        public ExtraIngredient ExtraIngredient { get; set; }

    }

}
