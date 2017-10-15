using System.ComponentModel.DataAnnotations;

namespace SimpleShop.Models
{
    public class UserCartItem
    {
        [Key]
        [Required]
        public int UserId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}