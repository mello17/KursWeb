namespace DAL.Web.Site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gfdf : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.News", "Header", c => c.String(nullable: false));
            AlterColumn("dbo.News", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.News", "imgPath", c => c.String(nullable: false));
            DropColumn("dbo.News", "AuthorProfileId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.News", "AuthorProfileId", c => c.String());
            AlterColumn("dbo.News", "imgPath", c => c.String());
            AlterColumn("dbo.News", "Content", c => c.String());
            AlterColumn("dbo.News", "Header", c => c.String());
        }
    }
}
