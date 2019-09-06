namespace CrmBl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Checks", "SellerId", "dbo.Sellers");
            DropIndex("dbo.Checks", new[] { "SellerId" });
            RenameColumn(table: "dbo.Checks", name: "SellerId", newName: "Seller_SellerId");
            DropPrimaryKey("dbo.Sellers");
            AddColumn("dbo.Checks", "SellergId", c => c.Int(nullable: false));
            AddColumn("dbo.Sellers", "SellerId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Checks", "Seller_SellerId", c => c.Int());
            AddPrimaryKey("dbo.Sellers", "SellerId");
            CreateIndex("dbo.Checks", "Seller_SellerId");
            AddForeignKey("dbo.Checks", "Seller_SellerId", "dbo.Sellers", "SellerId");
            DropColumn("dbo.Sellers", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sellers", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Checks", "Seller_SellerId", "dbo.Sellers");
            DropIndex("dbo.Checks", new[] { "Seller_SellerId" });
            DropPrimaryKey("dbo.Sellers");
            AlterColumn("dbo.Checks", "Seller_SellerId", c => c.Int(nullable: false));
            DropColumn("dbo.Sellers", "SellerId");
            DropColumn("dbo.Checks", "SellergId");
            AddPrimaryKey("dbo.Sellers", "Id");
            RenameColumn(table: "dbo.Checks", name: "Seller_SellerId", newName: "SellerId");
            CreateIndex("dbo.Checks", "SellerId");
            AddForeignKey("dbo.Checks", "SellerId", "dbo.Sellers", "Id", cascadeDelete: true);
        }
    }
}
