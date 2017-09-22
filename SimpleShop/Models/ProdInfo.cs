using System.ComponentModel.DataAnnotations;

namespace SimpleShop.Models
{
    public class ProdInfo
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int ShopId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public double Price { get; set; }

        public ProdInfo() // upon creation, products are set at default Quantity of 10, and default Price of 0
        {
            this.Quantity = 10;
            this.Price = 0;
        }
    }
}