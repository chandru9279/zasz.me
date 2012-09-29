using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using Xunit;
using zasz.health.UtilityTests;
using zasz.me;
using zasz.me.Integration.EntityFramework;
using zasz.me.Models;

namespace zasz.health.RepositoryTests
{
    // TODO: This class/suite is an unholy MESS - clean it up
    public class PostAndTagRepositoryTests : IDisposable
    {
        private readonly TestContext testContext;
        private readonly Posts posts;
        private readonly Tags tags;

        public PostAndTagRepositoryTests()
        {
           Database.SetInitializer(new TestStorageInitializer());
            testContext = new TestContext();
            tags = new Tags(testContext);
            posts = new Posts(testContext);
            var Count = posts.Count();
            if (Count != 0) return;
            var SamplePosts =
                new PostsData(Log).GetFromFolder(X.RepoPath + @"\Database\Legacy\Posts");
            foreach (var SamplePost in SamplePosts)
            {
                SamplePost.Tags =
                    SamplePost.Tags.Select(x => tags.Get(x.Name) ?? tags.Save(new Tag(x.Name))).ToList();
                posts.Save(SamplePost);
            }
            posts.Commit();
        }

        #region IDisposable Members

        public void Dispose()
        {
            testContext.Dispose();
        }

        #endregion

        [Fact]
        public void TestPagingAndSorting()
        {
            var Ids = new List<string> {"Moving-the-MBR-to-another-DeviceHard-Disk", "Home-PC-v30"};
            var Posts = posts.Page(0, 10);
            var ActualIds = Posts.Select(Post => Post.Slug).ToList();
            Assert.True(Ids.All(ActualIds.Contains));
        }

        [Fact]
        public void TestCount()
        {
            var Posts = posts.Count();
            Assert.True(Posts > 1);
        }

        [Fact]
        public void zz()
        {
            var Posts = posts.Get("Training-At-TWU");
            Assert.True(Posts.Id == Guid.Parse("E3D45333-B48C-4DDD-AD78-0258B5E0D76A"));
        }

        [Fact]
        public void TestTagPagingQuery()
        {
            var Posts = tags.PagePosts("asp.net", 0, 2);
            Assert.Equal(2, Posts.Count);

            Posts = tags.PagePosts("asp.net", 0, 100);
            Assert.Equal(7, Posts.Count);

            Posts = tags.PagePosts("games", 0, 100);
            Assert.Equal(7, Posts.Count);

            Posts = tags.PagePosts("dota", 0, 100);
            Assert.Equal(8, Posts.Count);
        }

        public void Log(string Log)
        {
            Console.WriteLine(Log);
        }
    }
}