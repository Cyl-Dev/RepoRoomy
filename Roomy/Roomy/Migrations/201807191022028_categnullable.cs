namespace Roomy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categnullable : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Rooms", "CategoryID", c => c.Int());
            //CreateIndex("dbo.Rooms", "CategoryID");
            AddForeignKey("dbo.Rooms", "CategoryID", "dbo.Categories", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "CategoryID", "dbo.Categories");
            //DropIndex("dbo.Rooms", new[] { "CategoryID" });
            //DropColumn("dbo.Rooms", "CategoryID");
        }
    }
}
