namespace Roomy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Civilities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Label = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RoomFiles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 254),
                        ContentType = c.String(nullable: false, maxLength: 100),
                        Content = c.Binary(nullable: false),
                        RoomID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Rooms", t => t.RoomID, cascadeDelete: true)
                .Index(t => t.RoomID);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CategoryID = c.Int(nullable: false),
                        Capacity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.CategoryID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(),
                        Mail = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Password = c.String(nullable: false),
                        CivilityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Civilities", t => t.CivilityID, cascadeDelete: true)
                .Index(t => t.CivilityID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "UserID", "dbo.Users");
            DropForeignKey("dbo.Users", "CivilityID", "dbo.Civilities");
            DropForeignKey("dbo.RoomFiles", "RoomID", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Users", new[] { "CivilityID" });
            DropIndex("dbo.Rooms", new[] { "UserID" });
            DropIndex("dbo.Rooms", new[] { "CategoryID" });
            DropIndex("dbo.RoomFiles", new[] { "RoomID" });
            DropTable("dbo.Users");
            DropTable("dbo.Rooms");
            DropTable("dbo.RoomFiles");
            DropTable("dbo.Civilities");
            DropTable("dbo.Categories");
        }
    }
}
