namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fir : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Groups", "Count_Of_Student");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Groups", "Count_Of_Student", c => c.Int(nullable: false));
        }
    }
}
