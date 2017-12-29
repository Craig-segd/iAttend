namespace iAttend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGUID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendees", "userId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attendees", "userId");
        }
    }
}
