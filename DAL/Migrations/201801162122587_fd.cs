namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fd : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Schedules", "Time");
           
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedules", "Time", c => c.DateTime(nullable: false));
        }
    }
}
