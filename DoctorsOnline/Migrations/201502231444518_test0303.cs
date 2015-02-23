namespace DoctorsOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test0303 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppointmentNo = c.Int(nullable: false),
                        AppointmentDate = c.DateTime(),
                        AppointmentTime = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        HospitalId = c.Int(nullable: false),
                        ChamberId = c.Int(nullable: false),
                        DoctorsInfo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chamber", t => t.ChamberId)
                .ForeignKey("dbo.DoctorsInfo", t => t.DoctorsInfo_Id)
                .ForeignKey("dbo.Hospital", t => t.HospitalId)
                .Index(t => t.HospitalId)
                .Index(t => t.ChamberId)
                .Index(t => t.DoctorsInfo_Id);
            
            CreateTable(
                "dbo.Chamber",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChamberName = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DoctorsInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorName = c.String(),
                        Qualification = c.String(),
                        Designation = c.String(),
                        Gender = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        VisitStartTime = c.DateTime(nullable: false),
                        VisitEndTime = c.DateTime(nullable: false),
                        HospitalId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        ChamberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chamber", t => t.ChamberId)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .ForeignKey("dbo.Hospital", t => t.HospitalId)
                .Index(t => t.HospitalId)
                .Index(t => t.DepartmentId)
                .Index(t => t.ChamberId);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                        Hospital_Id = c.Int(),
                        Organization_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hospital", t => t.Hospital_Id)
                .ForeignKey("dbo.Organization", t => t.Organization_Id)
                .Index(t => t.Hospital_Id)
                .Index(t => t.Organization_Id);
            
            CreateTable(
                "dbo.Hospital",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HospitalName = c.String(),
                        TotalDoctor = c.Int(nullable: false),
                        Phone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Organization",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganizationName = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationName = c.String(),
                        DoctorsInfoId = c.Int(nullable: false),
                        DivisionId = c.Int(nullable: false),
                        DistrictId = c.Int(nullable: false),
                        ThanaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Division", t => t.DivisionId)
                .ForeignKey("dbo.District", t => t.DistrictId)
                .ForeignKey("dbo.Thana", t => t.ThanaId)
                .ForeignKey("dbo.DoctorsInfo", t => t.DoctorsInfoId)
                .Index(t => t.DoctorsInfoId)
                .Index(t => t.DivisionId)
                .Index(t => t.DistrictId)
                .Index(t => t.ThanaId);
            
            CreateTable(
                "dbo.District",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DistrictName = c.String(),
                        DivisionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Division", t => t.DivisionId)
                .Index(t => t.DivisionId);
            
            CreateTable(
                "dbo.Division",
                c => new
                    {
                        DivisionId = c.Int(nullable: false, identity: true),
                        DivisionName = c.String(),
                    })
                .PrimaryKey(t => t.DivisionId);
            
            CreateTable(
                "dbo.Thana",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ThanaName = c.String(),
                        DistrictId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.District", t => t.DistrictId)
                .Index(t => t.DistrictId);
            
            CreateTable(
                "dbo.Prescription",
                c => new
                    {
                        PrescriptionId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        PatientFirstName = c.String(),
                        PatientLastName = c.String(),
                        PatientDOB = c.DateTime(nullable: false),
                        PatientSymption = c.String(),
                        OthersInfo = c.String(),
                        RequestDate = c.DateTime(nullable: false),
                        DocPrescrition = c.String(),
                        SubmissionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PrescriptionId);
            
            CreateTable(
                "dbo.UserPassword",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SlNo = c.Int(nullable: false),
                        Password = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.Int(),
                        CreateDate = c.DateTime(nullable: false),
                        ActionDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Location", "DoctorsInfoId", "dbo.DoctorsInfo");
            DropForeignKey("dbo.Location", "ThanaId", "dbo.Thana");
            DropForeignKey("dbo.Thana", "DistrictId", "dbo.District");
            DropForeignKey("dbo.Location", "DistrictId", "dbo.District");
            DropForeignKey("dbo.Location", "DivisionId", "dbo.Division");
            DropForeignKey("dbo.District", "DivisionId", "dbo.Division");
            DropForeignKey("dbo.Department", "Organization_Id", "dbo.Organization");
            DropForeignKey("dbo.DoctorsInfo", "HospitalId", "dbo.Hospital");
            DropForeignKey("dbo.Department", "Hospital_Id", "dbo.Hospital");
            DropForeignKey("dbo.Appointment", "HospitalId", "dbo.Hospital");
            DropForeignKey("dbo.DoctorsInfo", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.DoctorsInfo", "ChamberId", "dbo.Chamber");
            DropForeignKey("dbo.Appointment", "DoctorsInfo_Id", "dbo.DoctorsInfo");
            DropForeignKey("dbo.Appointment", "ChamberId", "dbo.Chamber");
            DropIndex("dbo.Thana", new[] { "DistrictId" });
            DropIndex("dbo.District", new[] { "DivisionId" });
            DropIndex("dbo.Location", new[] { "ThanaId" });
            DropIndex("dbo.Location", new[] { "DistrictId" });
            DropIndex("dbo.Location", new[] { "DivisionId" });
            DropIndex("dbo.Location", new[] { "DoctorsInfoId" });
            DropIndex("dbo.Department", new[] { "Organization_Id" });
            DropIndex("dbo.Department", new[] { "Hospital_Id" });
            DropIndex("dbo.DoctorsInfo", new[] { "ChamberId" });
            DropIndex("dbo.DoctorsInfo", new[] { "DepartmentId" });
            DropIndex("dbo.DoctorsInfo", new[] { "HospitalId" });
            DropIndex("dbo.Appointment", new[] { "DoctorsInfo_Id" });
            DropIndex("dbo.Appointment", new[] { "ChamberId" });
            DropIndex("dbo.Appointment", new[] { "HospitalId" });
            DropTable("dbo.UserRole");
            DropTable("dbo.UserPassword");
            DropTable("dbo.Prescription");
            DropTable("dbo.Thana");
            DropTable("dbo.Division");
            DropTable("dbo.District");
            DropTable("dbo.Location");
            DropTable("dbo.Organization");
            DropTable("dbo.Hospital");
            DropTable("dbo.Department");
            DropTable("dbo.DoctorsInfo");
            DropTable("dbo.Chamber");
            DropTable("dbo.Appointment");
        }
    }
}
