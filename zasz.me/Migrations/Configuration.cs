using System.Data.Entity.Migrations;
using zasz.me.Integration.EntityFramework;

namespace zasz.me.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<FullContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FullContext context)
        {
        }
    }
}