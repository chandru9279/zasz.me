using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Raven.Client.Document;
using Raven.Client.Indexes;
using zasz.develop.SampleData;
using zasz.me.Integration.RavenDB;
using zasz.me.Integration.RavenDB.Indexes;

namespace zasz.health.IntegrationTests
{
    [TestClass]
    public class PostRepositoryTests
    {
        private Posts Repo;
        private static DocumentStore _DocumentStore;

        [TestInitialize]
        public void Setup()
        {
            _DocumentStore = new DocumentStore { Url = "http://localhost:3000", DefaultDatabase = "TestStore" };
            _DocumentStore.Initialize();
            IndexCreation.CreateIndexes(typeof(Post_BySlug).Assembly, _DocumentStore);
            _DocumentStore.Conventions.FindIdentityProperty = RavenIntegration._FindIdentityProperty;
            Repo = new Posts(_DocumentStore.OpenSession());
            PostsData.GetFromFolder(@"C:\Documents and Settings\thiagac\My Documents\Visual Studio 2010\Projects\Posts", Log);
        }

        [TestMethod]
        public void TestSaving()
        {
            
        }

        public void Log(string Log)
        {
            Console.WriteLine(Log);
        }
    }
}
