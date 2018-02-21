namespace DAL.Web.Site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fff : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.News", "imgPath", c => c.String());
            DropColumn("dbo.News", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.News", "Type", c => c.String());
            AlterColumn("dbo.News", "imgPath", c => c.String(nullable: false));
        }
    }
}
