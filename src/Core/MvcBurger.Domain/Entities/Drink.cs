namespace MvcBurger.Domain.Entities
{
    public class Drink
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<MenuOrder> MenuOrder { get; set; }
    }

}
