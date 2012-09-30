using Xunit;
using zasz.health.UtilityTests;
using zasz.me.Integration.EntityFramework;

namespace zasz.health.RepositoryTests
{
    public class RepoBaseIntegrationTests : Fixture<PostAndTagsTestData>
    {
        private Tags tags;
        private Posts posts;

        protected override void InitFixture()
        {
            tags = new Tags(Context);
            posts = new Posts(Context);
        }

        [Fact]
        public void CountOfPostsIsThree()
        {
            var count = posts.Count();
            Assert.Equal(3, count);
        }

        [Fact]
        public void CountOfTagsIsAlsoThree()
        {
            var count = tags.Count();
            Assert.Equal(3, count);
        }
    }
}