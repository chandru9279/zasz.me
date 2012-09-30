using System;
using zasz.health.RepositoryTests;

namespace zasz.health.UtilityTests
{
    public class TestData : IDisposable
    {
    
        public bool NoCleanup { get; set; }

        public TestContext Context { get; set; }

        public TestData()
        {
            NoCleanup = false;
            Context = new TestContext();
        }

        public void DontCleanup()
        {
            NoCleanup = true;
        }

        public void Dispose()
        {
            if (NoCleanup) Context.Dispose(); 
            else Cleanup(); 
        }

        protected virtual void Cleanup()
        {
        }
    }
}