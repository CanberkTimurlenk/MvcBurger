using System.ComponentModel.DataAnnotations;

namespace MvcBurger.Web.Areas.Admin.Models
{
    public class MenuVM
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Required]
        [DataType(DataType.Url)]
        public string ImageUrl { get; set; }
    }
}
