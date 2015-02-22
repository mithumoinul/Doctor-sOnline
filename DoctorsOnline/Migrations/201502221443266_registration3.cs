namespace DoctorsOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class registration3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserInfo", "UserId", "dbo.User");
            DropForeignKey("dbo.UserPassword", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "User_Id", "dbo.User");
            DropIndex("dbo.UserInfo", new[] { "UserId" });
            DropIndex("dbo.UserPassword", new[] { "UserId" });
            DropIndex("dbo.UserRole", new[] { "User_Id" });
            DropColumn("dbo.UserPassword", "UserId");
            DropColumn("dbo.UserRole", "User_Id");
            DropTable("dbo.UserInfo");
            DropTable("dbo.User");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.String(),
                        NId = c.Int(nullable: false),
                        Address = c.String(),
                        Phone = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        ActionDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.UserRole", "User_Id", c => c.Int());
            AddColumn("dbo.UserPassword", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserRole", "User_Id");
            CreateIndex("dbo.UserPassword", "UserId");
            CreateIndex("dbo.UserInfo", "UserId");
            AddForeignKey("dbo.UserRole", "User_Id", "dbo.User", "Id");
            AddForeignKey("dbo.UserPassword", "UserId", "dbo.User", "Id");
            AddForeignKey("dbo.UserInfo", "UserId", "dbo.User", "Id");
        }
    }
}
