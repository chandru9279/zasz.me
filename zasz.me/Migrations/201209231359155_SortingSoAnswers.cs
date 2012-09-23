using System.Data.Entity.Migrations;

namespace zasz.me.Migrations
{
    public partial class SortingSoAnswers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SoAnswers", "Sort", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.SoAnswers", "Sort");
        }
    }
}