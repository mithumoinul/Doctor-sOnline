namespace DoctorsOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class exp2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DoctorsInfo", "Specialist", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DoctorsInfo", "Specialist");
        }
    }
}
