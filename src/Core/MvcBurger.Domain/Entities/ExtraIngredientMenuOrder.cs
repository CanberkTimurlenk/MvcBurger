namespace MvcBurger.Domain.Entities
{
    public class MenuOrderExtraIngredient
    {
        public Guid MenuOrderId { get; set; }
        public MenuOrder MenuOrder { get; set; }

        public Guid ExtraIngredientId { get; set; }
        public ExtraIngredient ExtraIngredient { get; set; }

    }

}
