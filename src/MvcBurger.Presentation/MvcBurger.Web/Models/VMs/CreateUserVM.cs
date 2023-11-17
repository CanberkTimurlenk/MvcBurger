using System.ComponentModel.DataAnnotations;

namespace MvcBurger.Web.Models.VMs
{
    public class CreateUserVM
    {
        [Required]
        [DataType(DataType.Text), MaxLength(20)]
        public string Firstname { get; set; }
        [Required]
        [DataType(DataType.Text), MaxLength(20)]
        public string Lastname { get; set; }
        [Required]
        [EmailAddress, MaxLength(320)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(6), MaxLength(20)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.MultilineText), MaxLength(255)]
        public string Address { get; set; }
        [Required]
        [MaxLength(20)]
        public string Username { get; set; }
    }
}
