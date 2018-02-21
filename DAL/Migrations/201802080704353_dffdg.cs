namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dffdg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "NumberLesson", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedules", "NumberLesson");
        }
    }
}
