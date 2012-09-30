using System.Data.Entity.Migrations;

namespace zasz.me.Migrations
{
    public partial class RenameMappingTagPostTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Blog.TagPosts", newName: "MapPostTag");
        }

        public override void Down()
        {
            RenameTable(name: "Blog.MapPostTag", newName: "TagPosts");
        }
    }
}