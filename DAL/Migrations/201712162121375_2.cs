namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jobs", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "Job_Id", "dbo.Jobs");
            DropIndex("dbo.Teachers", new[] { "JobId" });
            DropIndex("dbo.Teachers", new[] { "Job_Id" });
            DropIndex("dbo.Jobs", new[] { "Teacher_Id" });
            DropColumn("dbo.Teachers", "JobId");
            RenameColumn(table: "dbo.Teachers", name: "Job_Id", newName: "JobId");
            AlterColumn("dbo.Teachers", "JobId", c => c.Int(nullable: false));
            CreateIndex("dbo.Teachers", "JobId");
            AddForeignKey("dbo.Teachers", "JobId", "dbo.Jobs", "Id", cascadeDelete: true);
            DropColumn("dbo.Jobs", "Teacher_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "Teacher_Id", c => c.Int());
            DropForeignKey("dbo.Teachers", "JobId", "dbo.Jobs");
            DropIndex("dbo.Teachers", new[] { "JobId" });
            AlterColumn("dbo.Teachers", "JobId", c => c.Int());
            RenameColumn(table: "dbo.Teachers", name: "JobId", newName: "Job_Id");
            AddColumn("dbo.Teachers", "JobId", c => c.Int(nullable: false));
            CreateIndex("dbo.Jobs", "Teacher_Id");
            CreateIndex("dbo.Teachers", "Job_Id");
            CreateIndex("dbo.Teachers", "JobId");
            AddForeignKey("dbo.Teachers", "Job_Id", "dbo.Jobs", "Id");
            AddForeignKey("dbo.Jobs", "Teacher_Id", "dbo.Teachers", "Id");
        }
    }
}
