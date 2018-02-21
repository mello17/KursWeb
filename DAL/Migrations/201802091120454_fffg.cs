namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fffg : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Graduates", "Id", "dbo.ScienceWorks");
            DropIndex("dbo.Graduates", new[] { "Id" });
            DropPrimaryKey("dbo.Graduates");
            AddColumn("dbo.Graduates", "ScienceWorkId", c => c.Int(nullable: false));
            AlterColumn("dbo.Graduates", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Graduates", "Id");
            CreateIndex("dbo.Graduates", "ScienceWorkId");
            AddForeignKey("dbo.Graduates", "ScienceWorkId", "dbo.ScienceWorks", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Graduates", "ScienceWorkId", "dbo.ScienceWorks");
            DropIndex("dbo.Graduates", new[] { "ScienceWorkId" });
            DropPrimaryKey("dbo.Graduates");
            AlterColumn("dbo.Graduates", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Graduates", "ScienceWorkId");
            AddPrimaryKey("dbo.Graduates", "Id");
            CreateIndex("dbo.Graduates", "Id");
            AddForeignKey("dbo.Graduates", "Id", "dbo.ScienceWorks", "Id");
        }
    }
}
