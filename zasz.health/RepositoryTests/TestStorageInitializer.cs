using System.Data.Entity;
using System.Data.Entity.Migrations;
using zasz.me.Integration.EntityFramework;

namespace zasz.health.RepositoryTests
{
    public class TestStorageInitializer : MigrateDatabaseToLatestVersion<TestContext, TestConfiguration>
    {
    }

    public class TestContext : FullContext
    {
        public TestContext() : base("TestContext")
        {
        }
    } 
    
    public class TestConfiguration : DbMigrationsConfiguration<TestContext>
    {
        public TestConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TestContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}