namespace MvcBurger.Application.Features.Orders.Commands.Create
{
    public record CreateOrderResponse
    {
        public string Name { get; init; }
        public decimal Price { get; init; }
    }
}
