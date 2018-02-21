namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fdgg : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Groups", "Group_Name", c => c.String(nullable: false));
            DropColumn("dbo.Groups", "Count_Of_Student");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Groups", "Count_Of_Student", c => c.Int(nullable: false));
            AlterColumn("dbo.Groups", "Group_Name", c => c.String());
        }
    }
}
