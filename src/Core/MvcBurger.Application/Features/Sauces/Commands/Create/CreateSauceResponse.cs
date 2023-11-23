namespace MvcBurger.Application.Features.Commands.Drinks.Create
{
    public record CreateSauceResponse
    {
        public string Name { get; init; }
        public decimal Price { get; init; }
    }
}
