using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using zasz.develop.Data;
using zasz.me.Areas.Shared.Models;
using zasz.me.Integration.EntityFramework;

namespace zasz.health.IntegrationTests
{
    [TestClass]
    public class PostAndTagRepositoryTests
    {
        private FullContext _FullContext;
        private Posts _Posts;
        private Tags _Tags;

        [TestInitialize]
        public void Setup()
        {
            Database.SetInitializer(new ColdStorageInitializer());
            _FullContext = new FullContext();
            _Tags = new Tags(_FullContext);
            _Posts = new Posts(_FullContext);
            var Count = _Posts.Count();
            if (Count != 0) return;
            var SamplePosts = PostsData.GetFromFolder(ConfigurationManager.AppSettings["ProjectRootPath"] + @"\Data-Tools-Setup\Posts", Log);
            foreach (Post SamplePost in SamplePosts)
            {
                SamplePost.Site = Site.Shared;
                SamplePost.Tags = SamplePost.Tags.Select(It => _Tags.Get(It.Name) ?? _Tags.Save(new Tag(It.Name))).ToList();
                _Posts.Save(SamplePost);
            }
            _Posts.Commit();
        }

        [TestMethod]
        public void TestPagingAndSorting()
        {
            var Ids = new List<string> { "Moving-the-MBR-to-another-DeviceHard-Disk", "Home-PC-v30" };
            var Posts = _Posts.Page(0, 10);
            var ActualIds = Posts.Select(Post => Post.Slug);
            CollectionAssert.IsSubsetOf(Ids, ActualIds.ToList());
        }


        [TestMethod]
        public void TestCount()
        {
            var Posts = _Posts.Count();
            var Both = _Posts.Count(Site.Shared);
            var Pro = _Posts.Count(Site.Pro);
            var Rest = _Posts.Count(Site.Rest);
            Assert.AreEqual(Both, Posts);
            Assert.AreEqual(Pro, Posts);
            Assert.AreEqual(Rest, Posts);
        }

        [TestMethod]
        public void TestTagPagingQuery()
        {
            var Posts = _Tags.PagePosts("asp.net", 0, 2, Site.Pro);
            Assert.AreEqual(2, Posts.Count);

            Posts = _Tags.PagePosts("asp.net", 0, 100, Site.Pro);
            Assert.AreEqual(7, Posts.Count);

            Posts = _Tags.PagePosts("games", 0, 100, Site.Pro);
            Assert.AreEqual(7, Posts.Count);

            Posts = _Tags.PagePosts("dota", 0, 100, Site.Pro);
            Assert.AreEqual(8, Posts.Count);
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