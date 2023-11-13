using MvcBurger.Domain.Enums;

namespace MvcBurger.Application.DTOs.Cart
{
    public class CartItemDto
    {
        public Guid Id { get; set; }
        public Size Size { get; set; }
        public int Amount { get; set; }
        public MenuDto Menu { get; set; }
        public DrinkDto Drink { get; set; }


        public IEnumerable<ExtraIngredientDto> ExtraIngredients { get; set; }

    }
}

