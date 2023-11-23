namespace MvcBurger.Application.Features.Commands.Drinks.Create
{
    public record CreateOrderItemResponse
    {
        public string Name { get; init; }
        public decimal Price { get; init; }
    }
}
