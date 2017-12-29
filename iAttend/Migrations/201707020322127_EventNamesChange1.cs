namespace iAttend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventNamesChange1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Attendees", "DateOfBirth", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Attendees", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
