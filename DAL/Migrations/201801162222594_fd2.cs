namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fd2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "TimeStartingSchedule", c => c.DateTime(nullable: true));
            AddColumn("dbo.Schedules", "TimeEndingSchedule", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedules", "TimeStartingSchedule");
            DropColumn("dbo.Schedules", "TimeEndingSchedule");
        }
    }
}
