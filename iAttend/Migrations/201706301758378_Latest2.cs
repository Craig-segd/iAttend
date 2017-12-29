namespace iAttend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Latest2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendees", "EventName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attendees", "EventName");
        }
    }
}
