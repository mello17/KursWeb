namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teachers", "DegreeId", "dbo.Degrees");
            DropForeignKey("dbo.Teachers", "JobId", "dbo.Jobs");
            DropIndex("dbo.Teachers", new[] { "JobId" });
            DropIndex("dbo.Teachers", new[] { "DegreeId" });
            AddColumn("dbo.Teachers", "Job", c => c.Int(nullable: false));
            AddColumn("dbo.Teachers", "Degree", c => c.Int(nullable: false));
            AddColumn("dbo.Teachers", "imgPath", c => c.String());
            AddColumn("dbo.Teachers", "Information", c => c.String());
            DropColumn("dbo.Teachers", "JobId");
            DropColumn("dbo.Teachers", "DegreeId");
           // DropTable("dbo.Degrees");
            //DropTable("dbo.Jobs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Degrees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Teachers", "DegreeId", c => c.Int(nullable: false));
            AddColumn("dbo.Teachers", "JobId", c => c.Int(nullable: false));
            DropColumn("dbo.Teachers", "Information");
            DropColumn("dbo.Teachers", "imgPath");
            DropColumn("dbo.Teachers", "Degree");
            DropColumn("dbo.Teachers", "Job");
            CreateIndex("dbo.Teachers", "DegreeId");
            CreateIndex("dbo.Teachers", "JobId");
            AddForeignKey("dbo.Teachers", "JobId", "dbo.Jobs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Teachers", "DegreeId", "dbo.Degrees", "Id", cascadeDelete: true);
        }
    }
}
