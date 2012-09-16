using System.Data.Entity;
using zasz.me.Integration.EntityFramework;

namespace zasz.health.IntegrationTests
{
    public class TestStorageInitializer : DropCreateDatabaseAlways<TestContext>
    {
    }

    public class TestContext : FullContext
    {
        public TestContext() : base("TestContext")
        {
        }
    }
}