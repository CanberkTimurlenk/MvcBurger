namespace MvcBurger.Domain.Entities
{
    public class ExtraIngredient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public ICollection<MenuOrderExtraIngredient> MenuOrderExtraIngredient { get; set; }

    }

}
