using System.ComponentModel.DataAnnotations;

namespace MvcBurger.Web.Areas.Admin.Models
{
    public class ExtraIngredientVM
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}
