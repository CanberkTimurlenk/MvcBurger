using MvcBurger.Application.Features.ExtraIngredients.Queries.GetAll;
using MvcBurger.Application.Features.Menus.Queries.GetAll;

namespace MvcBurger.Web.Areas.Admin.Models
{
    public class GetExtraIngredientsListVM
    {
        public IEnumerable<GetAllExtraIngredientResponseListItem> ExstraList { get; set; }
    }
}
