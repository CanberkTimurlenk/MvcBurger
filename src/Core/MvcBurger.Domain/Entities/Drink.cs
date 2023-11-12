using MvcBurger.Domain.Entities.Common;

namespace MvcBurger.Domain.Entities
{
    public class Drink : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public ICollection<OrderItem> MenuOrder { get; set; }
    }

}
