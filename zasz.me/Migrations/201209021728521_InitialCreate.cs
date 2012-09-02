using System.Data.Entity.Migrations;

namespace zasz.me.Migrations
{
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                         {
                             Id = c.Guid(nullable: false),
                             Slug = c.String(nullable: false),
                             Title = c.String(nullable: false),
                             Content = c.String(),
                             Timestamp = c.DateTime(nullable: false),
                             Site_Name = c.String(),
                         })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Tags",
                c => new
                         {
                             Id = c.Guid(nullable: false),
                             Name = c.String(),
                         })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Passphrases",
                c => new
                         {
                             Id = c.Guid(nullable: false),
                             PhraseDigest = c.String(nullable: false),
                             Name = c.String(),
                             OneTime = c.Boolean(nullable: false),
                         })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Logs",
                c => new
                         {
                             Id = c.Guid(nullable: false),
                             Error_ApplicationName = c.String(),
                             Error_HostName = c.String(),
                             Error_Type = c.String(),
                             Error_Source = c.String(),
                             Error_Message = c.String(),
                             Error_Detail = c.String(),
                             Error_User = c.String(),
                             Error_Time = c.DateTime(nullable: false),
                             Error_StatusCode = c.Int(nullable: false),
                             Error_WebHostHtmlMessage = c.String(),
                         })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.TagPosts",
                c => new
                         {
                             Tag_Id = c.Guid(nullable: false),
                             Post_Id = c.Guid(nullable: false),
                         })
                .PrimaryKey(t => new {t.Tag_Id, t.Post_Id})
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.Post_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Post_Id);
        }

        public override void Down()
        {
            DropIndex("dbo.TagPosts", new[] {"Post_Id"});
            DropIndex("dbo.TagPosts", new[] {"Tag_Id"});
            DropForeignKey("dbo.TagPosts", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.TagPosts", "Tag_Id", "dbo.Tags");
            DropTable("dbo.TagPosts");
            DropTable("dbo.Logs");
            DropTable("dbo.Passphrases");
            DropTable("dbo.Tags");
            DropTable("dbo.Posts");
        }
    }
}