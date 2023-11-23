namespace MvcBurger.Application.Features.Queries.Drinks.GetAll
{
    public class GetAllDrinksResponse
    {
        public IEnumerable<GetAllDrinksResponseListItem> List { get; set; }

    }

    public class GetAllDrinksResponseListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
