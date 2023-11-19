using System.ComponentModel.DataAnnotations;

namespace MvcBurger.Web.Models.VMs
{
    public class UserLoginVM
    {
        [Required]
        [MaxLength(320)]
        public string Email { get; init; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; init; }
    }
}
