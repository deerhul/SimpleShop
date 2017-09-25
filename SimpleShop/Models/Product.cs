using System.ComponentModel.DataAnnotations;

namespace SimpleShop.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int ProductId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Product")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Product Description")]
        public string Description { get; set; }

        [Display(Name = "Product Image")]
        public string ImageUrl { get; set; }
    }
}