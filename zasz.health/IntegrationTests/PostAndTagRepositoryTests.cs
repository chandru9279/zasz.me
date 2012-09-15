using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using Xunit;
using zasz.develop.Data;
using zasz.me.Integration.EntityFramework;
using zasz.me.Models;

namespace zasz.health.IntegrationTests
{
    public class PostAndTagRepositoryTests : IDisposable
    {
        private readonly FullContext _FullContext;
        private readonly Posts _Posts;
        private readonly Tags _Tags;

        public PostAndTagRepositoryTests()
        {
            Database.SetInitializer(new TestStorageInitializer());
            _FullContext = new FullContext();
            _Tags = new Tags(_FullContext);
            _Posts = new Posts(_FullContext);
            var Count = _Posts.Count();
            if (Count != 0) return;
            var SamplePosts =
                PostsData.GetFromFolder(
                    ConfigurationManager.AppSettings["ProjectRootPath"] + @"\Data-Tools-Setup\Posts", Log);
            foreach (var SamplePost in SamplePosts)
            {
                SamplePost.Tags =
                    SamplePost.Tags.Select(x => _Tags.Get(x.Name) ?? _Tags.Save(new Tag(x.Name))).ToList();
                _Posts.Save(SamplePost);
            }
            _Posts.Commit();
        }

        #region IDisposable Members

        public void Dispose()
        {
            _FullContext.Dispose();
        }

        #endregion

        [Fact]
        public void TestPagingAndSorting()
        {
            var Ids = new List<string> {"Moving-the-MBR-to-another-DeviceHard-Disk", "Home-PC-v30"};
            var Posts = _Posts.Page(0, 10);
            var ActualIds = Posts.Select(Post => Post.Slug).ToList();
            Assert.True(Ids.All(ActualIds.Contains));
        }

        [Fact]
        public void TestCount()
        {
            var Posts = _Posts.Count();
            Assert.True(Posts > 1);
        }

        [Fact]
        public void TestTagPagingQuery()
        {
            var Posts = _Tags.PagePosts("asp.net", 0, 2);
            Assert.Equal(2, Posts.Count);

            Posts = _Tags.PagePosts("asp.net", 0, 100);
            Assert.Equal(7, Posts.Count);

            Posts = _Tags.PagePosts("games", 0, 100);
            Assert.Equal(7, Posts.Count);

            Posts = _Tags.PagePosts("dota", 0, 100);
            Assert.Equal(8, Posts.Count);
        }

        public void Log(string Log)
        {
            Console.WriteLine(Log);
        }
    }
}