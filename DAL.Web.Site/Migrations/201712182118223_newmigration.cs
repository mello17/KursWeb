namespace DAL.Web.Site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Header = c.String(),
                        Content = c.String(),
                        CurrentDate = c.DateTime(nullable: false),
                        Type = c.String(),
                        AuthorProfileId = c.String(),
                        imgPath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhotoAlbums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path_To_Photo = c.String(),
                        Alt = c.String(),
                        Gallery = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PhotoAlbums");
            DropTable("dbo.News");
        }
    }
}
