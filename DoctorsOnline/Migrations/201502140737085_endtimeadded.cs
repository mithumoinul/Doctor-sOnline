namespace DoctorsOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class endtimeadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DoctorsInfo", "VisitStartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.DoctorsInfo", "VisitEndTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.DoctorsInfo", "VisitingTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DoctorsInfo", "VisitingTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.DoctorsInfo", "VisitEndTime");
            DropColumn("dbo.DoctorsInfo", "VisitStartTime");
        }
    }
}
