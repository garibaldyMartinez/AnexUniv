namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Springv10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Slug = c.String(),
                        Icon = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Category_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.Incomes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntityType = c.Int(nullable: false),
                        IncomeType = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EntityID = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Income_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.CourseLessonLearnedsPerStudents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LessonsId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                        Lesson_Id = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CourseLessonLearnedsPerStudent_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.LessonsPerCourses", t => t.Lesson_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy)
                .Index(t => t.Lesson_Id);
            
            CreateTable(
                "dbo.LessonsPerCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Content = c.String(),
                        Video = c.String(),
                        CourseId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_LessonsPerCourse_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CourseId)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Slug = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image1 = c.String(),
                        Image2 = c.String(),
                        Status = c.Int(nullable: false),
                        Vote = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryId = c.Int(nullable: false),
                        AuthorId = c.String(maxLength: 128),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Course_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CategoryId)
                .Index(t => t.AuthorId)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.ReviewsPerCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Vote = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comment = c.String(),
                        CourseId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ReviewsPerCourse_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.CourseId)
                .Index(t => t.UserId)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.UsersPerCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Completed = c.Boolean(nullable: false),
                        CourseId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UsersPerCourse_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.CourseId)
                .Index(t => t.UserId)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Credit", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersPerCourses", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UsersPerCourses", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.UsersPerCourses", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.UsersPerCourses", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.UsersPerCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.ReviewsPerCourses", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReviewsPerCourses", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReviewsPerCourses", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReviewsPerCourses", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReviewsPerCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseLessonLearnedsPerStudents", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CourseLessonLearnedsPerStudents", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.CourseLessonLearnedsPerStudents", "Lesson_Id", "dbo.LessonsPerCourses");
            DropForeignKey("dbo.LessonsPerCourses", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.LessonsPerCourses", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.LessonsPerCourses", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Courses", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.LessonsPerCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Courses", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Courses", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Courses", "AuthorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CourseLessonLearnedsPerStudents", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.CourseLessonLearnedsPerStudents", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Incomes", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Incomes", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Incomes", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Categories", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Categories", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Categories", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.UsersPerCourses", new[] { "DeletedBy" });
            DropIndex("dbo.UsersPerCourses", new[] { "UpdatedBy" });
            DropIndex("dbo.UsersPerCourses", new[] { "CreatedBy" });
            DropIndex("dbo.UsersPerCourses", new[] { "UserId" });
            DropIndex("dbo.UsersPerCourses", new[] { "CourseId" });
            DropIndex("dbo.ReviewsPerCourses", new[] { "DeletedBy" });
            DropIndex("dbo.ReviewsPerCourses", new[] { "UpdatedBy" });
            DropIndex("dbo.ReviewsPerCourses", new[] { "CreatedBy" });
            DropIndex("dbo.ReviewsPerCourses", new[] { "UserId" });
            DropIndex("dbo.ReviewsPerCourses", new[] { "CourseId" });
            DropIndex("dbo.Courses", new[] { "DeletedBy" });
            DropIndex("dbo.Courses", new[] { "UpdatedBy" });
            DropIndex("dbo.Courses", new[] { "CreatedBy" });
            DropIndex("dbo.Courses", new[] { "AuthorId" });
            DropIndex("dbo.Courses", new[] { "CategoryId" });
            DropIndex("dbo.LessonsPerCourses", new[] { "DeletedBy" });
            DropIndex("dbo.LessonsPerCourses", new[] { "UpdatedBy" });
            DropIndex("dbo.LessonsPerCourses", new[] { "CreatedBy" });
            DropIndex("dbo.LessonsPerCourses", new[] { "CourseId" });
            DropIndex("dbo.CourseLessonLearnedsPerStudents", new[] { "Lesson_Id" });
            DropIndex("dbo.CourseLessonLearnedsPerStudents", new[] { "DeletedBy" });
            DropIndex("dbo.CourseLessonLearnedsPerStudents", new[] { "UpdatedBy" });
            DropIndex("dbo.CourseLessonLearnedsPerStudents", new[] { "CreatedBy" });
            DropIndex("dbo.CourseLessonLearnedsPerStudents", new[] { "UserId" });
            DropIndex("dbo.Incomes", new[] { "DeletedBy" });
            DropIndex("dbo.Incomes", new[] { "UpdatedBy" });
            DropIndex("dbo.Incomes", new[] { "CreatedBy" });
            DropIndex("dbo.Categories", new[] { "DeletedBy" });
            DropIndex("dbo.Categories", new[] { "UpdatedBy" });
            DropIndex("dbo.Categories", new[] { "CreatedBy" });
            DropColumn("dbo.AspNetUsers", "Credit");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "Name");
            DropTable("dbo.UsersPerCourses",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UsersPerCourse_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.ReviewsPerCourses",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ReviewsPerCourse_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Courses",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Course_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.LessonsPerCourses",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_LessonsPerCourse_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.CourseLessonLearnedsPerStudents",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CourseLessonLearnedsPerStudent_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Incomes",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Income_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Categories",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Category_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
