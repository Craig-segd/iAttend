namespace iAttend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyProps : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Attendees", name: "Event_Id", newName: "EventId");
            RenameColumn(table: "dbo.Attendees", name: "Name_Id", newName: "NameId");
            RenameIndex(table: "dbo.Attendees", name: "IX_Name_Id", newName: "IX_NameId");
            RenameIndex(table: "dbo.Attendees", name: "IX_Event_Id", newName: "IX_EventId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Attendees", name: "IX_EventId", newName: "IX_Event_Id");
            RenameIndex(table: "dbo.Attendees", name: "IX_NameId", newName: "IX_Name_Id");
            RenameColumn(table: "dbo.Attendees", name: "NameId", newName: "Name_Id");
            RenameColumn(table: "dbo.Attendees", name: "EventId", newName: "Event_Id");
        }
    }
}
