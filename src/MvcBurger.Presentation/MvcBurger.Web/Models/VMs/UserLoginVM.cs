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
        [MinLength(6), MaxLength(20)]
        public string Password { get; init; }
    }
}
