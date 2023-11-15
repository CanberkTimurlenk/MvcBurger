using MvcBurger.Domain.Entities;
using MvcBurger.Domain.Enums;

namespace MvcBurger.Application.Features.OrderItems.Queries.GetById
{
    public class GetByIdOrderItemResponse
    {
        public Guid MenuId { get; set; }
        public int Amount { get; set; }
        public Guid OrderId { get; set; }
        public Guid DrinkId { get; set; }
        public Size Size { get; set; }
        public ICollection<OrderItemExtraIngredient>? OrderItemExtraIngredient { get; set; }
    }
}
