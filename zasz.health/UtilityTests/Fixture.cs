using System.Data.Entity;
using Xunit;
using zasz.health.RepositoryTests;

namespace zasz.health.UtilityTests
{
    public class Fixture<T> : IUseFixture<T> where T : TestData, new()
    {
        protected T TestData;
        protected TestContext Context;

        public Fixture()
        {
            Database.SetInitializer(new TestStorageInitializer());
        }

        public void SetFixture(T data)
        {
            TestData = data;
            Context = data.Context;
            InitFixture();
        }

        protected virtual void InitFixture()
        {
        }
    }
}