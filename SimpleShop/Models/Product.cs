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
        public string ProductName { get; set; }

        [Required]
        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}