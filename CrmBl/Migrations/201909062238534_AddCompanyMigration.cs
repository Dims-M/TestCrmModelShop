namespace CrmBl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Checks", "SellerId", "dbo.Sellers");
            DropForeignKey("dbo.Sellers", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.Sellers", new[] { "Product_ProductId" });
            RenameColumn(table: "dbo.Sellers", name: "Product_ProductId", newName: "ProductId");
            DropPrimaryKey("dbo.Sellers");
            AddColumn("dbo.Checks", "Seller_Id", c => c.Int());
            AddColumn("dbo.Sellers", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Sellers", "Chek_Id", c => c.Int());
            AlterColumn("dbo.Sellers", "SellerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Sellers", "ProductId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Sellers", "Id");
            CreateIndex("dbo.Checks", "Seller_Id");
            CreateIndex("dbo.Sellers", "ProductId");
            CreateIndex("dbo.Sellers", "Chek_Id");
            AddForeignKey("dbo.Sellers", "Chek_Id", "dbo.Checks", "Id");
            AddForeignKey("dbo.Checks", "Seller_Id", "dbo.Sellers", "Id");
            AddForeignKey("dbo.Sellers", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.Checks", "SellerId", "dbo.Sellers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Checks", "SellerId", "dbo.Sellers");
            DropForeignKey("dbo.Sellers", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Checks", "Seller_Id", "dbo.Sellers");
            DropForeignKey("dbo.Sellers", "Chek_Id", "dbo.Checks");
            DropIndex("dbo.Sellers", new[] { "Chek_Id" });
            DropIndex("dbo.Sellers", new[] { "ProductId" });
            DropIndex("dbo.Checks", new[] { "Seller_Id" });
            DropPrimaryKey("dbo.Sellers");
            AlterColumn("dbo.Sellers", "ProductId", c => c.Int());
            AlterColumn("dbo.Sellers", "SellerId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Sellers", "Chek_Id");
            DropColumn("dbo.Sellers", "Id");
            DropColumn("dbo.Checks", "Seller_Id");
            AddPrimaryKey("dbo.Sellers", "SellerId");
            RenameColumn(table: "dbo.Sellers", name: "ProductId", newName: "Product_ProductId");
            CreateIndex("dbo.Sellers", "Product_ProductId");
            AddForeignKey("dbo.Sellers", "Product_ProductId", "dbo.Products", "ProductId");
            AddForeignKey("dbo.Checks", "SellerId", "dbo.Sellers", "SellerId", cascadeDelete: true);
        }
    }
}
