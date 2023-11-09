namespace MvcBurger.Domain.Entities
{
    public class Menu
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ICollection<MenuOrder> MenuOrder { get; set; }

    }

}
