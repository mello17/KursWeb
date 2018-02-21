namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdd12 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Schedules", "TimeStartingSchedule", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Schedules", "TimeEndingSchedule", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Schedules", "TimeEndingSchedule", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Schedules", "TimeStartingSchedule", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
