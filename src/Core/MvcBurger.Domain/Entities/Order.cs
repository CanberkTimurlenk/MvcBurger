namespace MvcBurger.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public ICollection<MenuOrder> MenuOrder { get; set; }
        public ICollection<SauceOrder> SauceOrder { get; set; }

        public decimal TotalPrice { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public Size Size { get; set; }

    }

}
