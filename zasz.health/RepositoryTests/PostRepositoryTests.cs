using Xunit;
using zasz.health.UtilityTests;
using zasz.me.Integration.EntityFramework;

namespace zasz.health.RepositoryTests
{
    public class PostRepositoryTests : Fixture<PostAndTagsTestData>
    {
        private Posts posts;
        private Tags tags;

        protected override void InitFixture()
        {
            tags = new Tags(Context);
            posts = new Posts(Context);
        }

        [Fact, TimeTaken]
        public void PagingShouldReturnListOfPostsPageByPageDescendingOrderOfTimestamp()
        {
            var page = posts.Page(0, 2);
            Assert.Equal(page.Count, 2);
            Assert.Equal(TestData.Third.Id, page[0].Id);
            Assert.Equal(TestData.Second.Id, page[1].Id);
            page = posts.Page(1, 2);
            Assert.Equal(page.Count, 1);
            Assert.Equal(TestData.First.Id, page[0].Id);
        }
    }
}