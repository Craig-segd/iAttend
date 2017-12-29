namespace iAttend.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateEventTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Events (Id, Name) VALUES (1, 'MEN Arena')");
            Sql("INSERT INTO Events (Id, Name) VALUES (2, 'Tobacco Dock')");
            Sql("INSERT INTO Events (Id, Name) VALUES (3, 'NEC Arena')");
            Sql("INSERT INTO Events (Id, Name) VALUES (4, 'O2 Academy')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Events WHERE Id IN (1, 2, 3, 4)");
        }
    }
}
