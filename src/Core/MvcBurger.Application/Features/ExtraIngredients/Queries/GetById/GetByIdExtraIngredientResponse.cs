namespace MvcBurger.Application.Features.Queries.ExtraIngredients.GetById
{
    public class GetByIdExtraIngredientResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
