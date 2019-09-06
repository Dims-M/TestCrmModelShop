namespace CrmBl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Checks", "SellerId", "dbo.Sellers");
            DropPrimaryKey("dbo.Sellers");
            AddColumn("dbo.Sellers", "SellerId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Sellers", "SellerId");
            AddForeignKey("dbo.Checks", "SellerId", "dbo.Sellers", "SellerId", cascadeDelete: true);
            DropColumn("dbo.Sellers", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sellers", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Checks", "SellerId", "dbo.Sellers");
            DropPrimaryKey("dbo.Sellers");
            DropColumn("dbo.Sellers", "SellerId");
            AddPrimaryKey("dbo.Sellers", "Id");
            AddForeignKey("dbo.Checks", "SellerId", "dbo.Sellers", "Id", cascadeDelete: true);
        }
    }
}
