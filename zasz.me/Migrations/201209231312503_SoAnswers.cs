using System.Data.Entity.Migrations;

namespace zasz.me.Migrations
{
    public partial class SoAnswers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SoCaches",
                c => new
                         {
                             Id = c.Guid(nullable: false),
                             Timestamp = c.DateTime(nullable: false),
                         })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.SoAnswers",
                c => new
                         {
                             Id = c.Guid(nullable: false),
                             QuestionId = c.Int(nullable: false),
                             QuestionTitle = c.String(),
                             AnswerId = c.Int(nullable: false),
                             Cache_Id = c.Guid(nullable: false),
                         })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SoCaches", t => t.Cache_Id, cascadeDelete: true)
                .Index(t => t.Cache_Id);
        }

        public override void Down()
        {
            DropIndex("dbo.SoAnswers", new[] {"Cache_Id"});
            DropForeignKey("dbo.SoAnswers", "Cache_Id", "dbo.SoCaches");
            DropTable("dbo.SoAnswers");
            DropTable("dbo.SoCaches");
        }
    }
}