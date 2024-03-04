namespace TozeptyDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        UserName = c.String(maxLength: 255),
                        Email = c.String(maxLength: 255),
                        PhoneNumber = c.String(),
                        Password = c.String(maxLength: 255),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "IX_UniqueAdminUserName")
                .Index(t => t.Email, unique: true, name: "IX_UniqueAdminEmail");
            
        }
        
        public override void Down()
        {
            
        }
    }
}
