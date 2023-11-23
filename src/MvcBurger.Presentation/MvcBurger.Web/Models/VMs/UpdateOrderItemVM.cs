

using MvcBurger.Domain.Entities;
using MvcBurger.Domain.Enums;

namespace MvcBurger.Web.Models.VMs
{
    public class UpdateOrderItemVM
    {
        public Guid MenuId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public Size SelectedSize { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public Guid SelectedDrinkId { get; set; }
        public Guid SelectedExtraIngredientId { get; set; }

    }
}
