using MvcBurger.Domain.Enums;

namespace MvcBurger.Application.Features.Orders.Commands.Cart.Common
{
    public class OrderItemRequest
    {
        public Guid MenuId { get; set; }
        //public Guid OrderId { get; set; }
        public Guid DrinkId { get; set; }
        public int Amount { get; set; }
        public Size Size { get; set; }
        public IEnumerable<Guid> ExtraIngredientId { get; set; }
    }
}