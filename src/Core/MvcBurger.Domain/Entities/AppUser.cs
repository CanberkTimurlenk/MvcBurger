using Microsoft.AspNetCore.Identity;
using MvcBurger.Domain.Entities.Common;

namespace MvcBurger.Domain.Entities
{
    public class AppUser : IdentityUser, IEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
