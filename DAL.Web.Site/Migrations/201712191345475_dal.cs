namespace DAL.Web.Site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dal : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Announces");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Announces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Header = c.String(),
                        CurrentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
