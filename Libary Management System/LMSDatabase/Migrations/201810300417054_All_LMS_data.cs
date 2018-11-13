namespace LMSDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class All_LMS_data : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        Cover = c.String(maxLength: 255),
                        Edition = c.String(nullable: false, maxLength: 50),
                        LanguageId = c.Int(nullable: false),
                        Author = c.String(nullable: false, maxLength: 500),
                        Quantity = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        Description = c.String(maxLength: 1000),
                        isDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        isDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        isDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        isDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Librarians",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        DateOfBirth = c.DateTime(nullable: false),
                        GenderId = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 15),
                        Address = c.String(nullable: false, maxLength: 255),
                        isDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genders", t => t.GenderId, cascadeDelete: true)
                .Index(t => t.GenderId);
            
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RentalDate = c.DateTime(nullable: false),
                        BookId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        LibrarianId = c.Int(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                        isDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Librarians", t => t.LibrarianId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.LibrarianId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentIdentity = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 255),
                        LastName = c.String(nullable: false, maxLength: 255),
                        DateOfBirth = c.DateTime(nullable: false),
                        GenderId = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 15),
                        DepartmentId = c.Int(nullable: false),
                        Address = c.String(nullable: false, maxLength: 255),
                        isDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: false)
                .ForeignKey("dbo.Genders", t => t.GenderId, cascadeDelete: false)
                .Index(t => t.DepartmentId)
                .Index(t => t.GenderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Rentals", "LibrarianId", "dbo.Librarians");
            DropForeignKey("dbo.Rentals", "BookId", "dbo.Books");
            DropForeignKey("dbo.Librarians", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.Books", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.Books", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Rentals", new[] { "StudentId" });
            DropIndex("dbo.Students", new[] { "GenderId" });
            DropIndex("dbo.Students", new[] { "DepartmentId" });
            DropIndex("dbo.Rentals", new[] { "LibrarianId" });
            DropIndex("dbo.Rentals", new[] { "BookId" });
            DropIndex("dbo.Librarians", new[] { "GenderId" });
            DropIndex("dbo.Books", new[] { "LanguageId" });
            DropIndex("dbo.Books", new[] { "DepartmentId" });
            DropTable("dbo.Students");
            DropTable("dbo.Rentals");
            DropTable("dbo.Librarians");
            DropTable("dbo.Genders");
            DropTable("dbo.Languages");
            DropTable("dbo.Departments");
            DropTable("dbo.Books");
        }
    }
}
