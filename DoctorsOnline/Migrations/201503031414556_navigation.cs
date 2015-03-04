namespace DoctorsOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class navigation : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.DoctorsInfo", new[] { "HospitalId" });
            DropIndex("dbo.DoctorsInfo", new[] { "DepartmentId" });
            DropIndex("dbo.DoctorsInfo", new[] { "ChamberId" });
            RenameColumn(table: "dbo.DoctorsInfo", name: "ChamberId", newName: "Chamber_Id");
            RenameColumn(table: "dbo.DoctorsInfo", name: "DepartmentId", newName: "Department_Id");
            RenameColumn(table: "dbo.DoctorsInfo", name: "HospitalId", newName: "Hospital_Id");
            AlterColumn("dbo.DoctorsInfo", "DoctorName", c => c.String(nullable: false));
            AlterColumn("dbo.DoctorsInfo", "Phone", c => c.String(maxLength: 12));
            AlterColumn("dbo.DoctorsInfo", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.DoctorsInfo", "Hospital_Id", c => c.Int());
            AlterColumn("dbo.DoctorsInfo", "Department_Id", c => c.Int());
            AlterColumn("dbo.DoctorsInfo", "Chamber_Id", c => c.Int());
            CreateIndex("dbo.DoctorsInfo", "Chamber_Id");
            CreateIndex("dbo.DoctorsInfo", "Department_Id");
            CreateIndex("dbo.DoctorsInfo", "Hospital_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.DoctorsInfo", new[] { "Hospital_Id" });
            DropIndex("dbo.DoctorsInfo", new[] { "Department_Id" });
            DropIndex("dbo.DoctorsInfo", new[] { "Chamber_Id" });
            AlterColumn("dbo.DoctorsInfo", "Chamber_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.DoctorsInfo", "Department_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.DoctorsInfo", "Hospital_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.DoctorsInfo", "Email", c => c.String());
            AlterColumn("dbo.DoctorsInfo", "Phone", c => c.String());
            AlterColumn("dbo.DoctorsInfo", "DoctorName", c => c.String());
            RenameColumn(table: "dbo.DoctorsInfo", name: "Hospital_Id", newName: "HospitalId");
            RenameColumn(table: "dbo.DoctorsInfo", name: "Department_Id", newName: "DepartmentId");
            RenameColumn(table: "dbo.DoctorsInfo", name: "Chamber_Id", newName: "ChamberId");
            CreateIndex("dbo.DoctorsInfo", "ChamberId");
            CreateIndex("dbo.DoctorsInfo", "DepartmentId");
            CreateIndex("dbo.DoctorsInfo", "HospitalId");
        }
    }
}
