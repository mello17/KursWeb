namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Default1Sanya : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CountOfSemester = c.Int(nullable: false),
                        NumCourse = c.Int(nullable: false),
                        Teacher_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id)
                .Index(t => t.Teacher_Id);
            
            CreateTable(
                "dbo.Degrees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FIO = c.String(nullable: false),
                        JobId = c.Int(nullable: false),
                        DegreeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Degrees", t => t.DegreeId, cascadeDelete: true)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .Index(t => t.JobId)
                .Index(t => t.DegreeId);
            
            CreateTable(
                "dbo.Graduates",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FIO = c.String(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.ScienceWorks", t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.TeacherId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Group_Name = c.String(),
                        Count_Of_Student = c.Int(nullable: false),
                        Teacher_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id)
                .Index(t => t.Teacher_Id);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Auditory = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId)
                .Index(t => t.GroupId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.ScienceWorks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Theme = c.String(nullable: false, maxLength: 50),
                        ScienceDirection = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Groups", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.Graduates", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Graduates", "Id", "dbo.ScienceWorks");
            DropForeignKey("dbo.Schedules", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Schedules", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Schedules", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Graduates", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Teachers", "DegreeId", "dbo.Degrees");
            DropForeignKey("dbo.Courses", "Teacher_Id", "dbo.Teachers");
            DropIndex("dbo.Schedules", new[] { "CourseId" });
            DropIndex("dbo.Schedules", new[] { "GroupId" });
            DropIndex("dbo.Schedules", new[] { "TeacherId" });
            DropIndex("dbo.Groups", new[] { "Teacher_Id" });
            DropIndex("dbo.Graduates", new[] { "GroupId" });
            DropIndex("dbo.Graduates", new[] { "TeacherId" });
            DropIndex("dbo.Graduates", new[] { "Id" });
            DropIndex("dbo.Teachers", new[] { "DegreeId" });
            DropIndex("dbo.Teachers", new[] { "JobId" });
            DropIndex("dbo.Courses", new[] { "Teacher_Id" });
            DropTable("dbo.Jobs");
            DropTable("dbo.ScienceWorks");
            DropTable("dbo.Schedules");
            DropTable("dbo.Groups");
            DropTable("dbo.Graduates");
            DropTable("dbo.Teachers");
            DropTable("dbo.Degrees");
            DropTable("dbo.Courses");
        }
    }
}
