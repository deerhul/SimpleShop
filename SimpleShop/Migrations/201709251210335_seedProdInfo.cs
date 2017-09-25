namespace SimpleShop.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class seedProdInfo : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ProdInfoes (ProductId, ShopId, Quantity, Price) VALUES (3, 1, 12, 2.50)");
            Sql("INSERT INTO ProdInfoes (ProductId, ShopId, Quantity, Price) VALUES (4, 1, 50, 0.50)");
            Sql("INSERT INTO ProdInfoes (ProductId, ShopId, Quantity, Price) VALUES (5, 1, 5, 3)");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM ProdInfoes WHERE ProductId IN (3,4,5)");
        }
    }
}
