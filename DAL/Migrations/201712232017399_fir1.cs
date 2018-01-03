namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fir1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groups", "Count_Of_Student", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Groups", "Count_Of_Student");
        }
    }
}
