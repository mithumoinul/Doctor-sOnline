namespace DoctorsOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteFullName : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserInfo", "FullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserInfo", "FullName", c => c.String());
        }
    }
}
