namespace MvcBurger.Domain.Entities
{
    public class SauceOrder
    {
        public Guid SauceId { get; set; }
        public Sauce Sauce { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }

}
