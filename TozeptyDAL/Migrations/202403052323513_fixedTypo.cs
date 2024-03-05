namespace TozeptyDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedTypo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Carts", new[] { "Customer_Id" });
            RenameColumn(table: "dbo.Carts", name: "Customer_Id", newName: "CustomerId");
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductName = c.String(),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        OrderStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            AddColumn("dbo.Customers", "RoleId", c => c.Int(nullable: false));
            AlterColumn("dbo.Carts", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "RoleId");
            CreateIndex("dbo.Carts", "CustomerId");
            CreateIndex("dbo.Orders", "CustomerID");
            AddForeignKey("dbo.Customers", "RoleId", "dbo.Roles", "RoleId", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "CustomerID", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Carts", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            DropColumn("dbo.Carts", "CusomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "CusomerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Carts", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Customers", "RoleId", "dbo.Roles");
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Carts", new[] { "CustomerId" });
            DropIndex("dbo.Customers", new[] { "RoleId" });
            AlterColumn("dbo.Carts", "CustomerId", c => c.Int());
            DropColumn("dbo.Customers", "RoleId");
            DropTable("dbo.OrderDetails");
            RenameColumn(table: "dbo.Carts", name: "CustomerId", newName: "Customer_Id");
            CreateIndex("dbo.Carts", "Customer_Id");
            AddForeignKey("dbo.Carts", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
