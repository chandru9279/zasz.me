using System.Data.Entity.Migrations;

namespace zasz.me.Migrations
{
    public partial class RenamingEntities : DbMigration
    {
        public override void Up()
        {
            MoveAndRename("SoAnswers", "Answers", "StackExchange");
            MoveAndRename("SoCaches", "Caches", "StackExchange");
            MoveTable("dbo.Posts", "Blog");
            MoveTable("dbo.Tags", "Blog");
            MoveTable("dbo.TagPosts", "Blog");
            MoveTable("dbo.Passphrases", "Manage");
            MoveTable("dbo.Logs", "Manage");
        }

        public override void Down()
        {
            OldNameAndMoveBack("SoAnswers", "Answers", "StackExchange");
            OldNameAndMoveBack("SoCaches", "Caches", "StackExchange");
            MoveTable("Blog.Posts", "dbo");
            MoveTable("Blog.Tags", "dbo");
            MoveTable("Blog.TagPosts", "dbo");
            MoveTable("Manage.Passphrases", "dbo");
            MoveTable("Manage.Logs", "dbo");
        }

        private void MoveAndRename(string oldName, string newName, string newSchema)
        {
            RenameTable(string.Format("dbo.{0}", oldName), newName);
            MoveTable(string.Format("dbo.{0}", newName), newSchema);
        }

        private void OldNameAndMoveBack(string oldName, string newName, string newSchema)
        {
            MoveTable(string.Format("{0}.{1}", newSchema, newName), "dbo");
            RenameTable(string.Format("dbo.{0}", newName), oldName);
        }
    }
}