namespace MvcBurger.Application.Features.Menus.Queries.GetAll
{
    public class GetAllMenusResponse
    {
        public IEnumerable<GetAllMenuResponseListItem> List { get; set; }

    }

    public class GetAllMenuResponseListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
