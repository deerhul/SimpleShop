using System.ComponentModel.DataAnnotations;

namespace SimpleShop.Models
{
    public class ProdInfo
    {
        [Key]
        public int ProdInfoId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int ShopId { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Item Price")]
        public double Price { get; set; }

        //public string ImageCollection { get; set; }

        public ProdInfo() // upon creation, products are set at default Quantity of 10, and default Price of 0
        {
            this.Quantity = 10;
            this.Price = 0;
        }

        /*
         * FOR CAROUSEL DISPLAY.
         * - store the image links as a string seperated by ",".
         * - create a method to separate the imgurl strings into separate strings and store in an array/collection
         * - (might have to create another class to store both 'Product' and 'ProdInfo' to pass to view to utilize both)
         * 
         * 
         * - for 'details' section. 
         * NOTE: string containing all URL of image separated by ",".
         * display via carousel.
         */
    }
}