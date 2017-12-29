namespace iAttend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Latest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attendees", "NameId", "dbo.AspNetUsers");
            DropIndex("dbo.Attendees", new[] { "NameId" });
            AlterColumn("dbo.Attendees", "NameId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Attendees", "NameId");
            AddForeignKey("dbo.Attendees", "NameId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendees", "NameId", "dbo.AspNetUsers");
            DropIndex("dbo.Attendees", new[] { "NameId" });
            AlterColumn("dbo.Attendees", "NameId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Attendees", "NameId");
            AddForeignKey("dbo.Attendees", "NameId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
