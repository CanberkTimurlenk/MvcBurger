using MvcBurger.Application.DTOs.Cart;

namespace MvcBurger.Application.Helpers
{
    public static class CartHelper
    {
        public static decimal GetTotalCartPrice(CartDto cartDto)
        {
            decimal total = 0;
            cartDto.CartItems.ToList().ForEach(cartItem =>
            {
                total += cartItem.Menu.Price * cartItem.Amount;
                cartItem.ExtraIngredients.ToList().ForEach(extraIngredient =>
                {
                    total += extraIngredient.Price * cartItem.Amount;
                });
            });
            return total;
        }
    }
}
