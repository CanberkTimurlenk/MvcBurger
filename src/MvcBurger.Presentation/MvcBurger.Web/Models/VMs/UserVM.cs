using MvcBurger.Domain.Entities;

namespace MvcBurger.Web.Models.VMs
{
    public class UserVM
    {
        public string Address { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
