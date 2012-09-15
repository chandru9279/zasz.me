using System.Data.Entity.Migrations;

namespace zasz.me.Migrations
{
    public partial class RemoveSite : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "Site_Name");
        }

        public override void Down()
        {
            AddColumn("dbo.Posts", "Site_Name", c => c.String());
        }
    }
}