using System.Collections.Generic;

namespace SimpleShop.Models
{
    public class PPinfoCase
    {
        //this class is a ViewModel for binding several models together

        public Product Product { get; set; }
        public ProdInfo ProdInfo { get; set; }
        //public Shop Shop { get; set; }


        //traverse through list of 'ProdInfo' and match the product's ID to get the remaining details
        public void getItems(Product p1, List<ProdInfo> p2)
        {
            this.Product = p1;
            foreach (ProdInfo temp in p2)
            {
                if (p1.ProductId == temp.ProductId)
                {
                    this.ProdInfo = temp;
                }
            }
        }
    }
}