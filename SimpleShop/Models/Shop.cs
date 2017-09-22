using System.ComponentModel.DataAnnotations;

namespace SimpleShop.Models
{
    public class Shop
    {
        [Key]
        [Required]
        public int ShopId { get; set; }

        [Required]
        [StringLength(255)]
        public string ShopName { get; set; }

        [Required]
        public string ShopDescription { get; set; }
    }
}