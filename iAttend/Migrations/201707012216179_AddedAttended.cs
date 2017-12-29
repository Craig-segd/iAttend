namespace iAttend.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddedAttended : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendees", "Attended", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Attendees", "Attended");
        }
    }
}
