namespace SimpleShop.Models
{
    public class PPinfoCase
    {
        public Product Product { get; set; }
        public ProdInfo ProdInfo { get; set; }

        public PPinfoCase(Product Product, ProdInfo ProdInfo)
        {
            this.Product = Product;
            this.ProdInfo = ProdInfo;
        }
    }
}