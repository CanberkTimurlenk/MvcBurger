using MvcBurger.Application.Features.ExtraIngredients.Queries.GetAll;
using MvcBurger.Application.Features.Queries.Drinks.GetAll;

namespace MvcBurger.Web.Models.VMs
{
    public class SelectedMenuVM
    {
        public Guid MenuId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public Guid SelectedDrinkId { get; set; }
        public Guid SelectedExtraIngredientId { get; set; }

        public IEnumerable<GetAllExtraIngredientResponseListItem> ExtraIngredients { get; set; }
        public IEnumerable<GetAllDrinksResponseListItem> Drinks { get; set; }
    }
}
