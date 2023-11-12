namespace MvcBurger.Application.Features.Commands.Drinks.Create
{
    public record CreateOrderItemExtraIngredientResponse
    {
        public string Name { get; init; }
        public decimal Price { get; init; }
    }
}
