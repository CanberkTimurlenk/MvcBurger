namespace MvcBurger.Application.Features.SauceOrders.Commands.Create
{
    public record CreateSauceOrderResponse
    {
        public string Name { get; init; }
        public decimal Price { get; init; }
    }
}
