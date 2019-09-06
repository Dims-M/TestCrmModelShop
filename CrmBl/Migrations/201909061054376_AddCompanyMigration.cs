namespace CrmBl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Checks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        SellerId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Seller_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Sellers", t => t.Seller_Id)
                .ForeignKey("dbo.Sellers", t => t.SellerId, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.SellerId)
                .Index(t => t.Seller_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SellId = c.Int(nullable: false),
                        Name = c.String(),
                        ProductId = c.Int(nullable: false),
                        Chek_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Checks", t => t.Chek_Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.Chek_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Selles",
                c => new
                    {
                        SellId = c.Int(nullable: false, identity: true),
                        ChekId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Check_Id = c.Int(),
                    })
                .PrimaryKey(t => t.SellId)
                .ForeignKey("dbo.Checks", t => t.Check_Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.Check_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Selles", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Selles", "Check_Id", "dbo.Checks");
            DropForeignKey("dbo.Checks", "SellerId", "dbo.Sellers");
            DropForeignKey("dbo.Sellers", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Checks", "Seller_Id", "dbo.Sellers");
            DropForeignKey("dbo.Sellers", "Chek_Id", "dbo.Checks");
            DropForeignKey("dbo.Checks", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Selles", new[] { "Check_Id" });
            DropIndex("dbo.Selles", new[] { "ProductId" });
            DropIndex("dbo.Sellers", new[] { "Chek_Id" });
            DropIndex("dbo.Sellers", new[] { "ProductId" });
            DropIndex("dbo.Checks", new[] { "Seller_Id" });
            DropIndex("dbo.Checks", new[] { "SellerId" });
            DropIndex("dbo.Checks", new[] { "CustomerID" });
            DropTable("dbo.Selles");
            DropTable("dbo.Products");
            DropTable("dbo.Sellers");
            DropTable("dbo.Customers");
            DropTable("dbo.Checks");
        }
    }
}
