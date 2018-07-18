namespace Roomy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AbandonnerColonneCorfirmedPassword : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "ConfirmedPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "ConfirmedPassword", c => c.String());
        }
    }
}
