namespace iAttend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteredName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendees", "_Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attendees", "_Name");
        }
    }
}
