namespace MvcBurger.Application.DTOs.Cart
{
    public class CartDto
    {
        public decimal TotalPrice { get; set; }
        public IEnumerable<CartItemDto> CartItems { get; set; }
    }
}

