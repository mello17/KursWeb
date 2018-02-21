namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdd123 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Schedules", "TimeStartingSchedule", c => c.String(nullable: false));
            AlterColumn("dbo.Schedules", "TimeEndingSchedule", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Schedules", "TimeEndingSchedule", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Schedules", "TimeStartingSchedule", c => c.DateTime(nullable: false));
        }
    }
}
