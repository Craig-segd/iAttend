namespace iAttend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConventions : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attendees", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Attendees", "Name_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Attendees", new[] { "Event_Id" });
            DropIndex("dbo.Attendees", new[] { "Name_Id" });
            AlterColumn("dbo.Attendees", "JobTitle", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Attendees", "Company", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Attendees", "Event_Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Attendees", "Name_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Events", "Name", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.Attendees", "Event_Id");
            CreateIndex("dbo.Attendees", "Name_Id");
            AddForeignKey("dbo.Attendees", "Event_Id", "dbo.Events", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Attendees", "Name_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendees", "Name_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Attendees", "Event_Id", "dbo.Events");
            DropIndex("dbo.Attendees", new[] { "Name_Id" });
            DropIndex("dbo.Attendees", new[] { "Event_Id" });
            AlterColumn("dbo.Events", "Name", c => c.String());
            AlterColumn("dbo.Attendees", "Name_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Attendees", "Event_Id", c => c.Byte());
            AlterColumn("dbo.Attendees", "Company", c => c.String());
            AlterColumn("dbo.Attendees", "JobTitle", c => c.String());
            CreateIndex("dbo.Attendees", "Name_Id");
            CreateIndex("dbo.Attendees", "Event_Id");
            AddForeignKey("dbo.Attendees", "Name_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Attendees", "Event_Id", "dbo.Events", "Id");
        }
    }
}
