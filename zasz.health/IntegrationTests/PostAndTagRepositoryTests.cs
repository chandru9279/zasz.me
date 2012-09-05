using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using Xunit;
using zasz.develop.Data;
using zasz.me.Areas.Shared.Models;
using zasz.me.Integration.EntityFramework;

namespace zasz.health.IntegrationTests
{
    public class PostAndTagRepositoryTests : IDisposable
    {
        private FullContext _FullContext;
        private Posts _Posts;
        private Tags _Tags;

        public PostAndTagRepositoryTests()
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

        [Fact]
        public void TestPagingAndSorting()
        {
            var Ids = new List<string> { "Moving-the-MBR-to-another-DeviceHard-Disk", "Home-PC-v30" };
            var Posts = _Posts.Page(0, 10);
            var ActualIds = Posts.Select(Post => Post.Slug).ToList();
            Assert.True(Ids.All(ActualIds.Contains));
        }


        [Fact]
        public void TestCount()
        {
            var Posts = _Posts.Count();
            var Both = _Posts.Count(Site.Shared);
            var Pro = _Posts.Count(Site.Pro);
            var Rest = _Posts.Count(Site.Rest);
            Assert.Equal(Both, Posts);
            Assert.Equal(Pro, Posts);
            Assert.Equal(Rest, Posts);
        }

        [Fact]
        public void TestTagPagingQuery()
        {
            var Posts = _Tags.PagePosts("asp.net", 0, 2, Site.Pro);
            Assert.Equal(2, Posts.Count);

            Posts = _Tags.PagePosts("asp.net", 0, 100, Site.Pro);
            Assert.Equal(7, Posts.Count);

            Posts = _Tags.PagePosts("games", 0, 100, Site.Pro);
            Assert.Equal(7, Posts.Count);

            Posts = _Tags.PagePosts("dota", 0, 100, Site.Pro);
            Assert.Equal(8, Posts.Count);
        }

        public void Log(string Log)
        {
            Console.WriteLine(Log);
        }

        public void Dispose()
        {
            _FullContext.Dispose();
        }
    }
}