using MvcBurger.Domain.Entities.Common;
using MvcBurger.Domain.Enums;

namespace MvcBurger.Domain.Entities
{
    public class Order : BaseEntity, IEntity
    {
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<SauceOrder> SauceOrder { get; set; }

        public decimal TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
