namespace TozeptyDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTablewithmoreEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.RoleId);
            
            AddColumn("dbo.Products", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Products", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Description", c => c.String(nullable: false));
            CreateIndex("dbo.Products", "CategoryId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
            DropColumn("dbo.Products", "ProductName");
            DropColumn("dbo.Products", "ProductQuantity");
            DropColumn("dbo.Products", "ProductDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ProductDescription", c => c.String(nullable: false));
            AddColumn("dbo.Products", "ProductQuantity", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "ProductName", c => c.String(nullable: false));
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Addresses", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Addresses", new[] { "CustomerId" });
            DropColumn("dbo.Products", "Description");
            DropColumn("dbo.Products", "Quantity");
            DropColumn("dbo.Products", "Name");
            DropTable("dbo.Roles");
            DropTable("dbo.Categories");
            DropTable("dbo.Addresses");
        }
    }
}
