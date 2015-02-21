namespace DoctorsOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class location : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.District", new[] { "LocationId" });
            DropIndex("dbo.Division", new[] { "LocationId" });
            DropIndex("dbo.Thana", new[] { "LocationId" });
            RenameColumn(table: "dbo.Location", name: "LocationId", newName: "DistrictId");
            RenameColumn(table: "dbo.Location", name: "LocationId", newName: "DivisionId");
            RenameColumn(table: "dbo.Location", name: "LocationId", newName: "ThanaId");
            AddColumn("dbo.Location", "DoctorsInfoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Location", "DoctorsInfoId");
            CreateIndex("dbo.Location", "DivisionId");
            CreateIndex("dbo.Location", "DistrictId");
            CreateIndex("dbo.Location", "ThanaId");
            AddForeignKey("dbo.Location", "DoctorsInfoId", "dbo.DoctorsInfo", "Id");
            DropColumn("dbo.District", "LocationId");
            DropColumn("dbo.Division", "LocationId");
            DropColumn("dbo.Thana", "LocationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Thana", "LocationId", c => c.Int(nullable: false));
            AddColumn("dbo.Division", "LocationId", c => c.Int(nullable: false));
            AddColumn("dbo.District", "LocationId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Location", "DoctorsInfoId", "dbo.DoctorsInfo");
            DropIndex("dbo.Location", new[] { "ThanaId" });
            DropIndex("dbo.Location", new[] { "DistrictId" });
            DropIndex("dbo.Location", new[] { "DivisionId" });
            DropIndex("dbo.Location", new[] { "DoctorsInfoId" });
            DropColumn("dbo.Location", "DoctorsInfoId");
            RenameColumn(table: "dbo.Location", name: "ThanaId", newName: "LocationId");
            RenameColumn(table: "dbo.Location", name: "DivisionId", newName: "LocationId");
            RenameColumn(table: "dbo.Location", name: "DistrictId", newName: "LocationId");
            CreateIndex("dbo.Thana", "LocationId");
            CreateIndex("dbo.Division", "LocationId");
            CreateIndex("dbo.District", "LocationId");
        }
    }
}
