namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fir1 : DbMigration
    {
        public override void Up()
        {
           DropColumn("dbo.Schedules", "Time");
           AddColumn("dbo.Schedules", "TimeStartingSchedule", c=>c.DateTime(nullable: true));
           AddColumn("dbo.Schedules", "TimeEndingSchedule", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedules", "Time", c=>c.DateTime(nullable: false));
            DropColumn("dbo.Schedules", "TimeStartingSchedule");
            DropColumn("dbo.Schedules", "TimeEndingSchedule");

        }
    }
}
