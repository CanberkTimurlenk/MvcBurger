namespace MvcBurger.Application.Features.ExtraIngredients.Queries.GetAll
{
    public class GetAllExtraIngredientsResponse
    {
        public IEnumerable<GetAllExtraIngredientResponseListItem> List { get; set; }
    }

    public class GetAllExtraIngredientResponseListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
