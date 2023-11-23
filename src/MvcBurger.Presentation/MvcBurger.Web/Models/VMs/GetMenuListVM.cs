using MvcBurger.Application.Features.Menus.Queries.GetAll;

namespace MvcBurger.Web.Models.VMs
{
    public class GetMenuListVM
    {
        public IEnumerable<GetAllMenuResponseListItem> MenuList { get; set; }
    }
}
