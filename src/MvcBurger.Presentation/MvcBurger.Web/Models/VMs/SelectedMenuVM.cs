using Microsoft.AspNetCore.Mvc.Rendering;
using MvcBurger.Application.Features.ExtraIngredients.Queries.GetAll;
using MvcBurger.Application.Features.Queries.Drinks.GetAll;
using MvcBurger.Domain.Entities;
using MvcBurger.Domain.Enums;

namespace MvcBurger.Web.Models.VMs
{
    public class SelectedMenuVM
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

        public List<SelectedExtraItem> Extras { get; set; }
        public ICollection<OrderItemExtraIngredient> SelectedExtraIngredients { get; set; }

        public List<GetAllExtraIngredientResponseListItem> AllExtraIngredients { get; set; }
        public List<GetAllDrinksResponseListItem> AllDrinks { get; set; }
    }



    public class SelectedExtraItem
    {
        public string ExtraName { get; set; }
        public bool Checked { get; set; }
        public Guid SelectedIngredientId { get; set; }
    }
}
