namespace SimpleShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserCartItemModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserCartItems",
                c => new
                    {
                        UserCartId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserCartId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserCartItems");
        }
    }
}
