using MvcBurger.Application.Features.Menus.Queries.GetAll;

namespace MvcBurger.Web.Models.VMs
{
    public class GetMenuListVM
    {
        public string? UserId { get; set; }
        public IEnumerable<GetAllMenuResponseListItem> MenuList { get; set; }
    }
}
