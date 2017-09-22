namespace SimpleShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedConventionsForProductAndShop : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Shops", "ShopName", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Shops", "ShopName", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false));
        }
    }
}
