namespace iAttend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Latest1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Attendees", name: "NameId", newName: "Name_Id");
            RenameIndex(table: "dbo.Attendees", name: "IX_NameId", newName: "IX_Name_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Attendees", name: "IX_Name_Id", newName: "IX_NameId");
            RenameColumn(table: "dbo.Attendees", name: "Name_Id", newName: "NameId");
        }
    }
}
