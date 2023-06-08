namespace EFRelations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Associates_Courses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Associates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseAssociates",
                c => new
                    {
                        Course_Id = c.Int(nullable: false),
                        Associate_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Course_Id, t.Associate_Id })
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .ForeignKey("dbo.Associates", t => t.Associate_Id, cascadeDelete: true)
                .Index(t => t.Course_Id)
                .Index(t => t.Associate_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseAssociates", "Associate_Id", "dbo.Associates");
            DropForeignKey("dbo.CourseAssociates", "Course_Id", "dbo.Courses");
            DropIndex("dbo.CourseAssociates", new[] { "Associate_Id" });
            DropIndex("dbo.CourseAssociates", new[] { "Course_Id" });
            DropTable("dbo.CourseAssociates");
            DropTable("dbo.Courses");
            DropTable("dbo.Associates");
        }
    }
}
