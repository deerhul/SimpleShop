namespace SimpleShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserCartModelNewKey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserCartItems");
            AlterColumn("dbo.UserCartItems", "UserId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UserCartItems", "UserId");
            DropColumn("dbo.UserCartItems", "UserCartId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserCartItems", "UserCartId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.UserCartItems");
            AlterColumn("dbo.UserCartItems", "UserId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.UserCartItems", "UserCartId");
        }
    }
}
