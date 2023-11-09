namespace MvcBurger.Domain.Entities
{
    public class Sauce
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<SauceOrder> SauceOrder { get; set; }
    }

}
