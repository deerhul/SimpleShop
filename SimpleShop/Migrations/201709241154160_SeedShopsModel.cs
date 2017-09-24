namespace SimpleShop.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedShopsModel : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Shops (ShopName, ShopDescription) VALUES ('Werribee OfficeWorks','a branch of officeworks located at Werribee')");
            Sql("INSERT INTO Shops (ShopName, ShopDescription) VALUES ('Tarneit School Supplies','Shop for students at Tarneit')");
            Sql("INSERT INTO Shops (ShopName, ShopDescription) VALUES ('Hoppers Crossing BookStore','A Bookstore at the HopsX bruh')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Shops WHERE ShopName IN (Werribee OfficeWorks','Tarneit School Supplies','Hoppers Crossing BookStore') ");
        }
    }
}
