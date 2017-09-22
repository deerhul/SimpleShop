namespace SimpleShop.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateTables : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Products (ProductName, Description) VALUES ('Pencil', '')");
            Sql("INSERT INTO Products (ProductName, Description) VALUES ('Paper', '')");
            Sql("INSERT INTO Products (ProductName, Description) VALUES ('Eraser', '')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Products WHERE ProductName IN ('Pencil', 'Paper', 'Eraser')");
        }
    }
}
