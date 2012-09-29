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
    }
}