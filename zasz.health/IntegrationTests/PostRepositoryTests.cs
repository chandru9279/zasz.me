using System;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using zasz.develop.SampleData;
using zasz.me.Integration.EntityFramework;
using zasz.me.Models;

namespace zasz.health.IntegrationTests
{
    [TestClass]
    public class PostRepositoryTests
    {
        private static FullContext _FullContext;
        private Posts _Repo;

        [TestInitialize]
        public void Setup()
        {
            Database.SetInitializer(new ColdStorageInitializer());
            _FullContext = new FullContext();
            _Repo = new Posts(_FullContext);
            var Count = _Repo.Count();
            if (Count == 0)
            {
                var SamplePosts = PostsData.GetFromFolder(@"C:\Documents and Settings\thiagac\My Documents\Visual Studio 2010\Projects\Confidence", Log);
                foreach (Post SamplePost in SamplePosts)
                    _Repo.Save(SamplePost);
                _Repo.Commit();
            }
        }

        [TestMethod]
        public void TestPaging()
        {
            var IDS = new List<string> {"End of Holidays in Horizon :(", "Getting-started-with-Apache-Struts-2-2c-with-Netbeans-61"};
            var Posts = _Repo.Page(0, 10);
            var ActualIDS = new List<string>(10);
            Posts.ForEach(Post => ActualIDS.Add(Post.Title));
            Assert.IsTrue(IDS.TrueForAll(ActualIDS.Contains));
        }

        [TestCleanup]
        public void TearDown()
        {
            _FullContext.Dispose();
        }

        public void Log(string Log)
        {
            Console.WriteLine(Log);
        }
    }
}