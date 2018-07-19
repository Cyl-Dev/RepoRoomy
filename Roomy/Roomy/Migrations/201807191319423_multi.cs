namespace Roomy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class multi : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rooms", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rooms", "Description", c => c.String(nullable: false));
        }
    }
}
