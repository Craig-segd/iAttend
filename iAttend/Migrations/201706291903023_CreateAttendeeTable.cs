namespace iAttend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAttendeeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfBirth = c.DateTime(nullable: false),
                        JobTitle = c.String(),
                        Company = c.String(),
                        Event_Id = c.Byte(),
                        Name_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Event_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Name_Id)
                .Index(t => t.Event_Id)
                .Index(t => t.Name_Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendees", "Name_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Attendees", "Event_Id", "dbo.Events");
            DropIndex("dbo.Attendees", new[] { "Name_Id" });
            DropIndex("dbo.Attendees", new[] { "Event_Id" });
            DropTable("dbo.Events");
            DropTable("dbo.Attendees");
        }
    }
}
