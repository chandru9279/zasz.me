using System;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using zasz.develop.SampleData;
using zasz.me.Controllers.Utils;
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
            PostsData.RegisterSites();
            _FullContext = new FullContext();
            _Repo = new Posts(_FullContext);
            var Count = _Repo.Count();
            if (Count == 0)
            {
                var SamplePosts = PostsData.GetFromFolder(Environment.GetEnvironmentVariable("SampleDataPath", EnvironmentVariableTarget.Machine), Log);
                foreach (Post SamplePost in SamplePosts)
                {
                    SamplePost.Site = Site.WithName("Both");
                    _Repo.Save(SamplePost);
                }
                _Repo.Commit();
            }
        }

        [TestMethod]
        public void TestPaging()
        {
            var Ids = new List<string> {"Fact-and-Fiction", "Getting-started-with-Apache-Struts-2-2c-with-Netbeans-61"};
            var Posts = _Repo.Page(0, 10);
            var ActualIds = Posts.Collect(Post => Post.Slug);
            Assert.IsTrue(Ids.TrueForAll(ActualIds.Contains));
        }


        [TestMethod]
        public void TestCount()
        {
            var Posts = _Repo.Count();
            var Both = _Repo.Count(Site.WithName("Both"));
            var Pro = _Repo.Count(Site.WithName("Pro"));
            var Rest = _Repo.Count(Site.WithName("Rest"));
            Assert.AreEqual(Both, Posts);
            Assert.AreEqual(Pro, Posts);
            Assert.AreEqual(Rest, Posts);
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