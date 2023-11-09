using System.ComponentModel.DataAnnotations.Schema;

namespace MvcBurger.Domain.Entities
{
    [NotMapped]
    public class User
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}
