using SimpleShop.Models;
using System.Data.Entity;

namespace SimpleShop.Context
{
    public class SimpleShopDbContext : DbContext
    {
        public SimpleShopDbContext() : base("SimpleShopContext")
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProdInfo> ProductInfo { get; set; }
        public DbSet<Shop> Shops { get; set; }
        //public DbSet<Shop> Shops { getl; set; }
    }
}