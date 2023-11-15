using Microsoft.AspNetCore.Mvc.Rendering;
using MvcBurger.Application.Features.ExtraIngredients.Queries.GetAll;
using MvcBurger.Application.Features.Queries.Drinks.GetAll;
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

        public List<selectListBenzeri> ekstralar { get; set; }

        public List<SelectListItem> Sizes { get; set; }
        public List<GetAllExtraIngredientResponseListItem> ExtraIngredients { get; set; }
        public List<GetAllDrinksResponseListItem> Drinks { get; set; }
    }



    public class selectListBenzeri {
        public string EkstraMalzemeAdi { get; set; }
        public bool IstiyorMusun { get; set; }
        public Guid SelectedIngredientId { get; set; }
    }
}
